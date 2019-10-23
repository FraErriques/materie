using System;


namespace Entity_materie.BusinessEntities
{
    /// <summary>
    /// this prototype is an attempture to insert in the same [materie].[dbo].[docMulti] table, but each document in one chunk only, whatever the size.
    /// Such attempt is motivated by errors occurring in the recomposition of the binary stream, in download from the database to the web-server and then
    /// to the web-client. Maybe the subdivision in chunks provokes the transmission protocols (i.e. tcp/ip from db-server to web-server and back and
    /// http from web-client to web-server and back) to add further data packets, which let the binary stream invalid. A solution has proven to be the 
    /// editing and remotion of trailng data after the EOF. A better solution, on the application side, would be to avoid the subdivision in chunks.
    /// If it works, new documents will be added in a single  [materie].[dbo].[docMulti] row, which will have ref_job_id==0 meaning that it has no previous
    /// chunk; its abstract will be different from _##__fake_abstract__##_
    /// 
    /// integral script of the Entity_materie/BusinessEntities/doc_multi on Ms-Sql-Server:
    /// USE [materie]
    //
    ////CREATE TABLE [dbo].[docMulti](
    ////    [id] [int] IDENTITY(1,1) NOT NULL,
    ////    [ref_job_id] [int] NOT NULL,
    ////    [ref_autore_id] [int] NOT NULL,
    ////    [ref_materia_id] [int] NOT NULL,
    ////    [abstract] [text] NOT NULL,
    ////    [sourceName] [varchar](550) NOT NULL,
    ////    [doc] [image] NULL,
    ////    [insertion_time] [datetime] NULL,
    //// CONSTRAINT [pk_doc_multi] PRIMARY KEY CLUSTERED 
    ////(
    ////    [id] ASC
    ////)
    ////GO
    //
    ////ALTER TABLE [dbo].[doc_multi]  WITH CHECK ADD  CONSTRAINT [fk_doc_multi_autore] FOREIGN KEY([ref_autore_id])
    ////REFERENCES [dbo].[autore] ([id])
    ////GO
    ////ALTER TABLE [dbo].[doc_multi] CHECK CONSTRAINT [fk_doc_multi_autore]
    ////GO
    //
    ////ALTER TABLE [dbo].[doc_multi]  WITH CHECK ADD  CONSTRAINT [fk_doc_multi_materia] FOREIGN KEY([ref_materia_id])
    ////REFERENCES [dbo].[materia_LOOKUP] ([id])
    ////GO
    ////ALTER TABLE [dbo].[doc_multi] CHECK CONSTRAINT [fk_doc_multi_materia]
    ////GO
    //
    ////ALTER TABLE [dbo].[doc_multi] ADD  DEFAULT ((0)) FOR [ref_job_id]
    ////GO
    //
    ////ALTER TABLE [dbo].[doc_multi] ADD  DEFAULT (getdate()) FOR [insertion_time]
    ////GO
    //
    /// </summary>
    public class docMono
    {
        #region data
        //---db record layout----
        private Int32 id;            // [id] [int] IDENTITY(1,1) NOT NULL, 
        private Int32 ref_job_id;    // [ref_job_id] [int] NOT NULL DEFAULT ((0)), 
        private Int32 ref_autore_id; // [ref_autore_id] [int] NOT NULL,         
        private Int32 ref_materia_id;// [ref_materia_id] [int] NOT NULL,         
        private string _abstract;    // [abstract] [text] NOT NULL,          
        private string sourceName;   // [sourceName] [varchar](550) NOT NULL,         
        private byte[] doc;          //[doc] [image] NULL,                           
        //private string insertion_time;// [insertion_time] [datetime] NULL,
        //----end---db-record-layout-----                                 
        // 
        private long docBody__Length = 0;// multi was...64 * 1024;// 64 Kb is the chunk size.-------------
        private string selectedFile = null;
        private Int32[] ids = null;
        private Int32 hm_ids = -1;
        //
        // TODO
        //---semantic tables----------
        #endregion data


        #region Ctors
        /// <summary>
        /// Ctor
        /// </summary>
        public docMono()
        { }

        /// <summary>
        //// partial initializer Ctor.
        /// </summary>
        public docMono(
         Int32 par_ref_autore_id
         ,Int32 par_ref_materia_id            
             )
        {
            this.ref_autore_id = par_ref_autore_id;
            this.ref_materia_id = par_ref_materia_id;
        }// partial initializer Ctor.

        /// <summary>
        /// initializing Ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ref_job_id"></param>
        /// <param name="id_autore"></param>
        /// <param name="_abstract"></param>
        /// <param name="sourceName"></param>
        /// <param name="doc"></param>
        public docMono(
            Int32 id,
            Int32 ref_job_id,
            Int32 ref_autore_id,
            Int32 ref_materia_id,
            string _abstract,
            string sourceName,
            byte[] doc
        )
        {
            this.id = id;
            this.ref_job_id = ref_job_id;
            this.ref_autore_id = ref_autore_id;
            this.ref_materia_id = ref_materia_id;
            this._abstract = _abstract;
            this.sourceName = sourceName;
            this.doc = doc;
        }// end Ctor



        /// <summary>
        /// initializing Ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ref_job_id"></param>
        /// <param name="id_autore"></param>
        /// <param name="_abstract"></param>
        /// <param name="sourceName"></param>
        /// <param name="doc"></param>
        public docMono(
            Int32 id,
            Int32 ref_job_id,
            Int32 ref_autore_id,
            Int32 ref_materia_id,
            string _abstract,
            string sourceName,
            string doc
        )
        {
            this.id = id;
            this.ref_job_id = ref_job_id;
            this.ref_autore_id = ref_autore_id;
            this.ref_materia_id = ref_materia_id;
            this._abstract = _abstract;
            this.sourceName = sourceName;
            this.doc = this.fromString_toByteArray(doc);// NB. parameter type translation.
        }// end Ctor
        #endregion Ctors



        #region helpers


        private byte[] fromString_toByteArray(string input)
        {
            int input_Length = input.Length;
            //
            byte[] res = new byte[input_Length];
            for (int c = 0; c < input_Length; c++)
            {
                res[c] = (byte)(input[c]);
            }
            // ready
            return res;
        }// end fromString_toByteArray


        #endregion helpers



        #region data_IO





        /// <summary>
        /// input into the db.
        /// </summary>
        /// <param name="idAutore"> the logged user</param>
        /// <param name="_abstract"> the text by means of which the semantic engine works </param>
        /// <param name="inputSelect_FileName"> the input file fullpath </param>
        /// <returns>
        /// a status integer:
        ///     0==success,
        ///     -1==failure.
        /// </returns>
        public Int32 FILE_from_FS_insertto_DB(
            int ref_candidato_id,
            int ref_materia_id,
            string _abstract,
            string inputSelect_FileName  // fullpath choosen
          )
        {
            LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                "Entity_materie.BusinessEntities.Doc_multi.FILE_from_FS_insertto_DB: "
                + inputSelect_FileName
                , 0);
            //
            if (
                null == _abstract
                || "" == _abstract.Trim())
            // Aborted on abstract insertion.
            {
                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                    "Aborted onabstract insertion. Documento non inserito.",
                    0);
                return -1;
            }// else can continue.
            //
            //---verify File-selection result.-----
            selectedFile = inputSelect_FileName;//   is member.
            if (
                null == selectedFile
                || "" == selectedFile
            )// Aborted on file-selection
            {
                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                    "Aborted on file-selection. Documento non inserito.",
                    0);
                return -1;
            }// else can continue.
            //
            int lastBackslashIndex = selectedFile.LastIndexOf(@"\");
            string fname = selectedFile.Substring(lastBackslashIndex + 1);
            // qualora mai servisse string extension = fname.Substring(fname.LastIndexOf(".") + 1); TODO ?needed?
            System.IO.FileStream theStream = null;
            // follow two control-variables, which are logged.
            Int32 lastGeneratedId = -1;// init to error.
            string actual_abstract = null;
            //
            try
            {
                // open, to read in chunks.
                //
                theStream = new System.IO.FileStream(
                    selectedFile,
                    System.IO.FileMode.Open,
                    System.IO.FileAccess.Read,
                    System.IO.FileShare.None // no sharing allowed.
                );
                if (null == theStream)// check open-read result.
                {
                    throw new System.Exception("unexisting file.");
                }// else can continue.
                Int64 longStreamLength = theStream.Length;
                double hm_chunks = +1;// multi was... (double)longStreamLength / (double)docBody__Length;
                double integer_hm_chunks = Math.Ceiling(hm_chunks);
                Int32 int_hm_chunks = (Int32)integer_hm_chunks;
                byte[] docBody = null;
                //---modified for Mono
                docBody__Length = theStream.Length;
                long readResult = docBody__Length;
                ////----DON'T acquire transaction: each insertion is wrapped with a get_max(id) in a stored-transacion. ---------
                int acc = 0;// chunk counter.
                int insertionProxyResult = -1;// init to error.
                //
                //---chunk loop----
                // means: finchè la lunghezza del chunk di file letto(readResult) e' uguale al chunk teorico; ovvero finche' non si
                // ha un chunk parzializzato per EOF.
                for (; docBody__Length == readResult; acc++)
                {
                    docBody = new byte[docBody__Length];
                    readResult = theStream.Read(docBody, 0, (Int32)docBody__Length);//----NB. SINGLE_chunk read.---------
                    if (0 == readResult)// means EOF was reached, in the previous step
                    {
                        break;
                    }// else if docBody__Length == readResult or (readResult<docBody__Length && readResult>0) means a last chunk of partial length, to 
                    // be inserted.
                    actual_abstract = null;
                    if (0 == acc)
                    {// NB. zero represents the pointer to null. Put it only on first chunk, to represent that no previous chunk exists.
                        lastGeneratedId = 0;
                    }
                    if (int_hm_chunks - 1 == acc)// last chunk: put the actual abstract.
                    {// tested: if the document is composed by one chunk only, the execution will pass only here; works fine.
                        actual_abstract = _abstract;//   actual abstract; ONLY in last chunk.
                    }
                    else// first or intermediate chunk
                    {
                        actual_abstract = "_##__fake_abstract__##_";//   actual abstract; ONLY in last chunk.
                    }
                    //
                    //-------what follows is unusefull since the upload-download http services always add chunks after EOF
                    //-------(typically html chunks), so it's unusefull to force packet truncation.
                    //
                    //----start---in test---truncation of last chunk for msWord 2007---------
                    byte[] lastChunk_truncated = null;
                    if (readResult < docBody__Length)
                    {
                        lastChunk_truncated = new byte[docBody__Length];// complete size, to swap into.
                        for (int c = 0; c < readResult; c++)// copy ONLY the notNULL bytes.
                        {
                            lastChunk_truncated[c] = docBody[c];// copy by value; reference would become invalid in a while.
                        }
                        docBody = null;
                        docBody = new byte[readResult];// reduced size.
                        for (int c = 0; c < readResult; c++)
                        {
                            docBody[c] = lastChunk_truncated[c];
                        }
                        //
                        lastChunk_truncated = null;//gc
                    }
                    ////----end-----in test---truncation of last chunk for msWord 2007---------
                    //
                    int newId = -1;// init to error.
                    insertionProxyResult =
                        Entity_materie.Proxies.usp_docMulti_INSERT_SERVICE.usp_docMulti_INSERT(
                            lastGeneratedId,
                            ref_candidato_id,
                            ref_materia_id,
                            actual_abstract,//   actual abstract; ONLY in last chunk.
                            fname,// sourceName
                            docBody,//--- current chunk ---------------
                            ref newId,
                            null // trx
                        );
                    lastGeneratedId = newId;// non e' eliminabile: il retval e' gia' occupato dall'insertionProxyResult.
                    //
                    if (0 >= lastGeneratedId
                        || 0 != insertionProxyResult)
                    {
                        throw new System.Exception("inserimento fallito per chunk di doc_multi.");
                    }
                    // else// insertion ok, and id_identity generated valid.
                    docBody = null;// Garbage Collect.
                }
                ////----DON'T dispose transaction: each insertion is wrapped with a get_max(id) in a stored-transacion. ---------
                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                    "Il documento e' stato pubblicato. Utilizzare le parole chiave dell'abstract per ricercarlo."
                    + " lastGeneratedId =" + lastGeneratedId.ToString()
                    + " abstract =" + actual_abstract.ToString(),
                    0);
            }//----end try
            catch (System.Exception ex)
            {
                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                    "Eccezione nell'inserimento di un doc_multi. ex= "
                    + ex.Message
                    + ". L' abstract era = " + actual_abstract,
                    0);
            }
            finally
            {
                if (null != theStream)
                {
                    theStream.Close();
                    theStream = null;//---garbage collect.-----
                }// else already ok.-------
            }
            // ready.
            return lastGeneratedId;// >0 means success.
        }//------- end /// input into the db.







        /// <summary>
        /// this is the unique access point to extract documents. Flow:
        ///     - it queries an Entity_materie::Proxy and extracts the blob
        ///     - saves on the original filename, at the User::tmp path, decorating with a dynamic string( time based).
        /// </summary>
        /// <param name="id"> the id-field, in the db record layout.</param>
        /// <returns>
        /// a status integer:
        ///     0==success,
        ///     -1==failure.
        /// </returns>
        public Int32 FILE_from_DB_writeto_FS(
            int id,
            out string extractionFullPath
            , string clientIP
          )
        {
            extractionFullPath = null;// compulsory init; actual initialization in body.
            if (0 >= id)
            {// invalid id.
                return -1;
            }// else can continue.
            //
            System.IO.FileStream multiChunk_stream = null;
            //
            try
            {
                System.Data.DataSet ds_allInvolvedIds =
                    Entity_materie.Proxies.usp_docMulti_dataMining_SERVICE.usp_docMulti_dataMining(id);
                if (null == ds_allInvolvedIds) throw new System.Exception("trouble connecting to database.");
                //
                //----revert the ids to their original order.--------
                hm_ids = ds_allInvolvedIds.Tables.Count;
                if (0 >= hm_ids
                    || 0 >= ds_allInvolvedIds.Tables[1].Rows.Count)// NB Tables[0] is static; doesn't count.
                {// invalid id.
                    return -1;
                }// else can continue.
                else// valid chunk group.
                {
                    ids = new Int32[hm_ids];
                    for (int c = 0; c < hm_ids; c++)
                    {
                        ids[c] = (Int32)(ds_allInvolvedIds.Tables[hm_ids - (c + 1)].Rows[0].ItemArray[0]);
                    }
                    string sourceName = null;
                    System.Data.DataTable dt_sourceName =
                        Entity_materie.Proxies.usp_docMulti_get_sourceName_SERVICE.usp_docMulti_get_sourceName(
                            ids[1]//--NB. skip first datatable row, which has id==0.
                    );
                    if (null != dt_sourceName
                        && 0 < dt_sourceName.Rows.Count)
                    {
                        sourceName = (string)(dt_sourceName.Rows[0].ItemArray[0]);
                        if (sourceName.Length > 60)
                        {
                            int last_dot_position = sourceName.LastIndexOf('.');
                            string extension = ".doc";// default
                            if (-1 < last_dot_position)
                            {
                                extension = sourceName.Substring(
                                    last_dot_position, 4);
                            }
                            // else  default to "doc".
                            sourceName = sourceName.Substring(0, 56) + extension;
                        }// else leave it as is.
                    }
                    else
                    {// invalid id.
                        return -1;
                    }// else can continue.
                    //
                    ConfigurationLayer.ConfigurationService cs = new
                        ConfigurationLayer.ConfigurationService("FileTransferTempPath/fullpath");
                    string dlgSave_InitialDirectory = cs.GetStringValue("path");
                    //-Gestione dismessa --- NB. it's different for every user, included ASPNETusr ---------
                    //-Gestione dismessa string dlgSave_InitialDirectory = Environment.GetEnvironmentVariable("tmp", EnvironmentVariableTarget.User);
                    //-Gestione dismessa string dlgSave_InitialDirectory = @"C:\root\LogSinkFs\cv";// TODO adapt to the server file sysetm.
                    dlgSave_InitialDirectory += "\\download";// from server to client.
                    //
                    // Ensure the folder exists
                    if (!System.IO.Directory.Exists(dlgSave_InitialDirectory))
                    {
                        System.IO.Directory.CreateDirectory(dlgSave_InitialDirectory);
                    }// else already present on the web server file system.
                    extractionFullPath =
                        dlgSave_InitialDirectory
                        + "\\"
                        + DateTime.Now.Year.ToString()
                        + DateTime.Now.Month.ToString()
                        + DateTime.Now.Day.ToString()
                        .Replace('/', '_').Replace('\\', '_')
                        .Replace(' ', '_').Replace('.', '_').Replace(':', '_')
                        .Replace(';', '_').Replace(',', '_')
                        + "_"
                        + sourceName;
                    if (null == clientIP || "" == clientIP)
                    {
                        clientIP = " unspecified. ";
                    }// else continue.
                    LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                        " extractionFullPath = " + extractionFullPath
                        + " _ clientIP = " + clientIP
                        , 0);
                    //--prepare the binary stream to append to.-----------
                    multiChunk_stream = new System.IO.FileStream(
                        extractionFullPath,
                        System.IO.FileMode.Append,
                        System.IO.FileAccess.Write,
                        System.IO.FileShare.None,
                        (Int32)docBody__Length * hm_ids// prepare a size of "n" chunks of 64Kb. The last one is generally not full: so it's surely enough.
                    );
                    if (null == multiChunk_stream) throw new System.Exception("unable to write the file.");
                    //---retrieve blob, foer each id.---------------------
                    for (int c = 1; c < hm_ids; c++)//--NB. skip first datatable row, which has id==0.
                    {
                        System.Data.DataTable dt_currentChunk =
                            Entity_materie.Proxies.usp_docMulti_getBlobAtId_SERVICE.usp_docMulti_getBlobAtId(
                                ids[c]
                        );
                        byte[] tmp_chunk = (byte[])(dt_currentChunk.Rows[0]["doc"]);
                        multiChunk_stream.Write(//NB.----write a single chunk on filesystem.----------------------
                            tmp_chunk,
                            0,
                            tmp_chunk.Length
                        );
                    }// end for
                    LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                        "OK, doc extracted.",
                        0);
                }// end else// valid chunk group.
            }// end try.---
            catch (System.Exception ex)// invalid id inserted
            {
                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                    "error while trying to retrieve a document: " + ex.Message,
                    0);
            }
            finally
            {
                ids = null;// reset.
                hm_ids = -1;// reset.
                if (null != multiChunk_stream)
                {
                    multiChunk_stream.Flush();
                    multiChunk_stream.Close();
                    multiChunk_stream = null;//---garbage collect.-----
                }//----------else already ok.----
            }
            //---ready---
            return 0;// means success.
        }//---end method----



        #endregion data_IO



    }// class

}// nmsp


#region cantina

//namespace Entity_materie.BusinessEntities
//{

//    /// <summary>
//    /// integral script of the Entity_materie/BusinessEntities/doc_multi on Ms-Sql-Server:
//    /// USE [materie]
//    //
//    ////CREATE TABLE [dbo].[docMulti](
//    ////    [id] [int] IDENTITY(1,1) NOT NULL,
//    ////    [ref_job_id] [int] NOT NULL,
//    ////    [ref_autore_id] [int] NOT NULL,
//    ////    [ref_materia_id] [int] NOT NULL,
//    ////    [abstract] [text] NOT NULL,
//    ////    [sourceName] [varchar](550) NOT NULL,
//    ////    [doc] [image] NULL,
//    ////    [insertion_time] [datetime] NULL,
//    //// CONSTRAINT [pk_doc_multi] PRIMARY KEY CLUSTERED 
//    ////(
//    ////    [id] ASC
//    ////)
//    ////GO
//    //
//    ////ALTER TABLE [dbo].[doc_multi]  WITH CHECK ADD  CONSTRAINT [fk_doc_multi_autore] FOREIGN KEY([ref_autore_id])
//    ////REFERENCES [dbo].[autore] ([id])
//    ////GO
//    ////ALTER TABLE [dbo].[doc_multi] CHECK CONSTRAINT [fk_doc_multi_autore]
//    ////GO
//    //
//    ////ALTER TABLE [dbo].[doc_multi]  WITH CHECK ADD  CONSTRAINT [fk_doc_multi_materia] FOREIGN KEY([ref_materia_id])
//    ////REFERENCES [dbo].[materia_LOOKUP] ([id])
//    ////GO
//    ////ALTER TABLE [dbo].[doc_multi] CHECK CONSTRAINT [fk_doc_multi_materia]
//    ////GO
//    //
//    ////ALTER TABLE [dbo].[doc_multi] ADD  DEFAULT ((0)) FOR [ref_job_id]
//    ////GO
//    //
//    ////ALTER TABLE [dbo].[doc_multi] ADD  DEFAULT (getdate()) FOR [insertion_time]
//    ////GO
//    //
//    /// </summary>
//    public class docMulti
//    {
//        #region data
//        //---db record layout----
//        private Int32 id;            // [id] [int] IDENTITY(1,1) NOT NULL, 
//        private Int32 ref_job_id;    // [ref_job_id] [int] NOT NULL DEFAULT ((0)), 
//        private Int32 ref_autore_id; // [ref_autore_id] [int] NOT NULL,         
//        private Int32 ref_materia_id;// [ref_materia_id] [int] NOT NULL,         
//        private string _abstract;    // [abstract] [text] NOT NULL,          
//        private string sourceName;   // [sourceName] [varchar](550) NOT NULL,         
//        private byte[] doc;          //[doc] [image] NULL,                           
//        //private string insertion_time;// [insertion_time] [datetime] NULL,
//        //----end---db-record-layout-----                                 
//        // 
//        private const Int32 docBody__Length = 64 * 1024;// 64 Kb is the chunk size.-------------
//        private string selectedFile = null;
//        private Int32[] ids = null;
//        private Int32 hm_ids = -1;
//        //
//        // TODO
//        //---semantic tables----------
//        #endregion data


//        #region Ctors
//        /// <summary>
//        /// Ctor
//        /// </summary>
//        public docMulti()
//        { }

//        /// <summary>
//        //// partial initializer Ctor.
//        /// </summary>
//        public docMulti(
//         Int32 par_ref_autore_id
//         ,Int32 par_ref_materia_id            
//             )
//        {
//            this.ref_autore_id = par_ref_autore_id;
//            this.ref_materia_id = par_ref_materia_id;
//        }// partial initializer Ctor.

//        /// <summary>
//        /// initializing Ctor
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="ref_job_id"></param>
//        /// <param name="id_autore"></param>
//        /// <param name="_abstract"></param>
//        /// <param name="sourceName"></param>
//        /// <param name="doc"></param>
//        public docMulti(
//            Int32 id,
//            Int32 ref_job_id,
//            Int32 ref_autore_id,
//            Int32 ref_materia_id,
//            string _abstract,
//            string sourceName,
//            byte[] doc
//        )
//        {
//            this.id = id;
//            this.ref_job_id = ref_job_id;
//            this.ref_autore_id = ref_autore_id;
//            this.ref_materia_id = ref_materia_id;
//            this._abstract = _abstract;
//            this.sourceName = sourceName;
//            this.doc = doc;
//        }// end Ctor



//        /// <summary>
//        /// initializing Ctor
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="ref_job_id"></param>
//        /// <param name="id_autore"></param>
//        /// <param name="_abstract"></param>
//        /// <param name="sourceName"></param>
//        /// <param name="doc"></param>
//        public docMulti(
//            Int32 id,
//            Int32 ref_job_id,
//            Int32 ref_autore_id,
//            Int32 ref_materia_id,
//            string _abstract,
//            string sourceName,
//            string doc
//        )
//        {
//            this.id = id;
//            this.ref_job_id = ref_job_id;
//            this.ref_autore_id = ref_autore_id;
//            this.ref_materia_id = ref_materia_id;
//            this._abstract = _abstract;
//            this.sourceName = sourceName;
//            this.doc = this.fromString_toByteArray(doc);// NB. parameter type translation.
//        }// end Ctor
//        #endregion Ctors



//        #region helpers


//        private byte[] fromString_toByteArray(string input)
//        {
//            int input_Length = input.Length;
//            //
//            byte[] res = new byte[input_Length];
//            for (int c = 0; c < input_Length; c++)
//            {
//                res[c] = (byte)(input[c]);
//            }
//            // ready
//            return res;
//        }// end fromString_toByteArray




//        /// <summary>
//        /// NB. the id_set parameter must be of the form:
//        ///     " (1,2,3)"
//        ///     in case of null or "" the where condition is not applied and all existing documents
//        ///     are retireved.
//        ///     The query is (approximately)
//        ///         'select 
//        ///	        	id, autore, abstract
//        ///	        from
//        ///	        	[dbo].[doc_multi] '    +
//        ///                 ' where id in ' + @id_set 
//        ///// </summary>
//        ///// <returns></returns>
//        //public System.Data.DataTable SearchByAll(
//        //    string id_set
//        //  )
//        //{// refers to usp_Documento_SEARCH_CandidateDocuments_SERVICE
//        //    System.Data.DataTable result = null;
//        //    //
//        //    result =
//        //        Entity_materie.Proxies.usp_doc_multi_SEARCH_CandidateDocuments_SERVICE.usp_doc_multi_SEARCH_CandidateDocuments(
//        //            id_set
//        //        );
//        //    //
//        //    return result;
//        //}// end Search() method.



//        #endregion helpers




//        #region semantic_search_engine


//        internal class CandidateDocument
//        {
//            public int id;
//            public string autore;
//            public string _abstract;
//            public double credibilityMeasure;
//            // Ctor
//            public CandidateDocument()
//            {
//                this.id = 0;
//                this._abstract = null;
//                this.credibilityMeasure = 0.0;
//            }// end Ctor
//        }
//        //
//        //
//        //
//        //
//        // the preceding class is devoted to the following method only:
//        public System.Data.DataTable SearchByAbstract(
//            string criteria
//            )
//        {// refers to usp_Documento_SEARCH_byAbstract_SERVICE
//            System.Data.DataTable result = null;
//            //
//            if (null == criteria)
//            {
//                return null;
//            }// else can continue.
//    //result =
//    //    Entity_materie.Proxies.usp_doc_multi_SEARCH_CandidateDocuments_SERVICE.usp_doc_multi_SEARCH_CandidateDocuments(
//    //        null // id_set not specified -> the semantic research on abstracts involves all docs.
//    //);
//            if (null == result)
//            {
//                return result;// exit on no-connection.
//            }// else continue.
//            int cardDocs = result.Rows.Count;
//            CandidateDocument[] measures = new CandidateDocument[cardDocs];
//            for (int c = 0; c < cardDocs; c++)
//            {
//                measures[c] = new CandidateDocument();
//                measures[c].id = (int)(result.Rows[c]["id"]);
//                measures[c].autore = (string)(result.Rows[c]["autore"]);
//                measures[c]._abstract = (string)(result.Rows[c]["abstract"]);
//                // go evaluate the credibility measure:
//                measures[c].credibilityMeasure = evaluateCredibilityMeasure(
//                    criteria,
//                    measures[c]._abstract
//                    );
//            }
//            //
//            // this table will be returned to BPL.
//            System.Data.DataTable PlausibleDocuments = new System.Data.DataTable("PlausibleDocuments");
//            PlausibleDocuments.Columns.Add("id", typeof(int));
//            PlausibleDocuments.Columns.Add("autore", typeof(string));
//            PlausibleDocuments.Columns.Add("abstract", typeof(string));
//            PlausibleDocuments.Columns.Add("credibilityMeasure", typeof(double));
//            // read through the measures[] and take only the plausible ones:
//            //      two criteria:
//            //          take the first "n", no more
//            //          don't go below a threshold, with matching measure
//            const double matchingThreshold = +.01;// TODO calibrate these model constants. It's the percentage of credibility of the matching.
//            const Int32 candidateCardinality = Int32.MaxValue;// NB. this represents plus infinity; meaning no threshold on how many docs can match.
//            for (int choosenElements = 0, currentElement = 0; choosenElements < candidateCardinality; currentElement++)
//            {
//                if (currentElement >= measures.Length) break;// don't scan more than available documents.
//                if (measures[currentElement].credibilityMeasure >= matchingThreshold)
//                {
//                    // TODO add to datatable
//                    object[] tmpRow = new object[4];
//                    tmpRow[0] = measures[currentElement].id;
//                    tmpRow[1] = measures[currentElement].autore;
//                    tmpRow[2] = measures[currentElement]._abstract;
//                    tmpRow[3] = measures[currentElement].credibilityMeasure;
//                    PlausibleDocuments.Rows.Add(tmpRow);
//                    ++choosenElements;
//                }// else skip
//            }// end for: onReached_CandidateCardinality exits.
//            // order by credibilityMeasure desc.
//            System.Data.DataRow[] orderedDocuments =
//                PlausibleDocuments.Select("", "credibilityMeasure DESC");
//            //
//            System.Data.DataTable orderedDocumentsTable = new System.Data.DataTable("orderedDocumentsTable");
//            orderedDocumentsTable.Columns.Add("id", typeof(int));
//            orderedDocumentsTable.Columns.Add("autore", typeof(string));
//            orderedDocumentsTable.Columns.Add("abstract", typeof(string));
//            orderedDocumentsTable.Columns.Add("credibilityMeasure", typeof(double));
//            for (int c = 0; c < orderedDocuments.Length; c++)
//            {
//                object[] tmpRow = new object[4];
//                tmpRow[0] = orderedDocuments[c]["id"];
//                tmpRow[1] = orderedDocuments[c]["autore"];
//                tmpRow[2] = orderedDocuments[c]["abstract"];
//                tmpRow[3] = orderedDocuments[c]["credibilityMeasure"];
//                orderedDocumentsTable.Rows.Add(tmpRow);
//            }
//            // ready
//            return orderedDocumentsTable;
//        }// end Search() method.



//        private double evaluateCredibilityMeasure(
//            string criteria,// NB. "criteria" stands for "user-request".
//            string docCorrente
//          )
//        {
//            if (null == criteria)
//            {
//                return 0.0;
//            }// else can continue.
//            char[] trailingChars = new char[5] { ' ', '\t', '\r', '\n', '_' };// TODO tune here the pruning delimiters.
//            string filteredCriteria =
//                Entity_materie.
//                    FormatConverters.CharConversion.substituteStrangeLetters(criteria);
//            filteredCriteria = filteredCriteria.Trim(trailingChars).ToUpper();
//            char[] criteriaSpittingChars = trailingChars;
//            string[] filteredCriteria_tokens = filteredCriteria.Split(
//            criteriaSpittingChars, StringSplitOptions.RemoveEmptyEntries);
//            string docCorrenteFiltrato = FormatConverters.CharConversion.substituteStrangeLetters(
//                docCorrente);
//            docCorrenteFiltrato = docCorrenteFiltrato.Trim(trailingChars).ToUpper();
//            string[] docCorrenteFiltrato_tokens = docCorrenteFiltrato.Split(
//                criteriaSpittingChars, StringSplitOptions.RemoveEmptyEntries);
//            //
//            double correspondence = 0.0;// the measure.
//            // each matching token, in the user request, contributes for a 1/n, having "n" tokens in the user request.
//            double measure_token = 1.0 / ((double)filteredCriteria_tokens.Length);
//            // for each token in currently examined document.
//            for (int curDocumentTok = 0; curDocumentTok < docCorrenteFiltrato_tokens.Length; curDocumentTok++)
//            {
//                // try-match it on a token in the user-requested-criteria.
//                for (int curCriteriumTok = 0; curCriteriumTok < filteredCriteria_tokens.Length; curCriteriumTok++)
//                {
//                    string criterium_token = filteredCriteria_tokens[curCriteriumTok].Substring(0, filteredCriteria_tokens[curCriteriumTok].Length - 1);
//                    string document_token = docCorrenteFiltrato_tokens[curDocumentTok].Substring(0, docCorrenteFiltrato_tokens[curDocumentTok].Length - 1);
//                    if (// compare except last letter, to match sigulars, plurals, male and female genders.
//                        criterium_token == document_token
//                        )
//                    {
//                        correspondence += measure_token;
//                    }// else do not decrease: nonnegative measure. end measure adjustment.
//                }// end for-each token in the user request.
//            }// end for-each token in the currently scanned database doc.
//            //ready
//            return correspondence;
//        }//



//        #endregion semantic_search_engine




//        #region data_IO





//        /// <summary>
//        /// input into the db.
//        /// </summary>
//        /// <param name="idAutore"> the logged user</param>
//        /// <param name="_abstract"> the text by means of which the semantic engine works </param>
//        /// <param name="inputSelect_FileName"> the input file fullpath </param>
//        /// <returns>
//        /// a status integer:
//        ///     0==success,
//        ///     -1==failure.
//        /// </returns>
//        public Int32 FILE_from_FS_insertto_DB(
//            int ref_candidato_id,
//            int ref_materia_id,
//            string _abstract,
//            string inputSelect_FileName  // fullpath choosen
//          )
//        {
//            LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
//                "Entity_materie.BusinessEntities.Doc_multi.FILE_from_FS_insertto_DB: "
//                + inputSelect_FileName
//                , 0);
//            //
//            if (
//                null == _abstract
//                || "" == _abstract.Trim())
//            // Aborted on abstract insertion.
//            {
//                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
//                    "Aborted onabstract insertion. Documento non inserito.",
//                    0);
//                return -1;
//            }// else can continue.
//            //
//            //---verify File-selection result.-----
//            selectedFile = inputSelect_FileName;//   is member.
//            if (
//                null == selectedFile
//                || "" == selectedFile
//            )// Aborted on file-selection
//            {
//                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
//                    "Aborted on file-selection. Documento non inserito.",
//                    0);
//                return -1;
//            }// else can continue.
//            //
//            int lastBackslashIndex = selectedFile.LastIndexOf(@"\");
//            string fname = selectedFile.Substring(lastBackslashIndex + 1);
//            // qualora mai servisse string extension = fname.Substring(fname.LastIndexOf(".") + 1); TODO ?needed?
//            System.IO.FileStream theStream = null;
//            // follow two control-variables, which are logged.
//            Int32 lastGeneratedId = -1;// init to error.
//            string actual_abstract = null;
//            //
//            try
//            {
//                // open, to read in chunks.
//                //
//                theStream = new System.IO.FileStream(
//                    selectedFile,
//                    System.IO.FileMode.Open,
//                    System.IO.FileAccess.Read,
//                    System.IO.FileShare.None // no sharing allowed.
//                );
//                if (null == theStream)// check open-read result.
//                {
//                    throw new System.Exception("unexisting file.");
//                }// else can continue.
//                Int64 longStreamLength = theStream.Length;
//                double hm_chunks = (double)longStreamLength / (double)docBody__Length;
//                double integer_hm_chunks = Math.Ceiling(hm_chunks);
//                Int32 int_hm_chunks = (Int32)integer_hm_chunks;
//                byte[] docBody = null;
//                int readResult = docBody__Length;
//                ////----DON'T acquire transaction: each insertion is wrapped with a get_max(id) in a stored-transacion. ---------
//                int acc = 0;// chunk counter.
//                int insertionProxyResult = -1;// init to error.
//                //
//                //---chunk loop----
//                for (; docBody__Length == readResult; acc++)
//                {
//                    docBody = new byte[docBody__Length];
//                    readResult = theStream.Read(docBody, 0, docBody__Length);//----NB. chunk read.---------
//                    //
//                    actual_abstract = null;
//                    if (0 == acc)
//                    {// NB. zero represents the pointer to null. Put it only on first chunk, to represent that no previous chunk exists.
//                        lastGeneratedId = 0;
//                    }
//                    if (int_hm_chunks - 1 == acc)// last chunk: put the actual abstract.
//                    {// tested: if the document is composed by one chunk only, the execution will pass only here; works fine.
//                        actual_abstract = _abstract;//   actual abstract; ONLY in last chunk.
//                    }
//                    else// first or intermediate chunk
//                    {
//                        actual_abstract = "_##__fake_abstract__##_";//   actual abstract; ONLY in last chunk.
//                    }
//                    //
//                    //-------what follows is unusefull since the upload-download http services always add chunks after EOF
//                    //-------(typically html chunks), so it's unusefull to force packet truncation.
//                    //
//                    //----start---in test---truncation of last chunk for msWord 2007---------
//                    byte[] lastChunk_truncated = null;
//                    if (readResult < docBody__Length)
//                    {
//                        lastChunk_truncated = new byte[docBody__Length];// complete size, to swap into.
//                        for (int c = 0; c < readResult; c++)// copy ONLY the notNULL bytes.
//                        {
//                            lastChunk_truncated[c] = docBody[c];// copy by value; reference would become invalid in a while.
//                        }
//                        docBody = null;
//                        docBody = new byte[readResult];// reduced size.
//                        for (int c = 0; c < readResult; c++)
//                        {
//                            docBody[c] = lastChunk_truncated[c];
//                        }
//                        //
//                        lastChunk_truncated = null;//gc
//                    }
//                    ////----end-----in test---truncation of last chunk for msWord 2007---------
//                    //
//                    int newId = -1;// init to error.
//                    insertionProxyResult =
//                        Entity_materie.Proxies.usp_docMulti_INSERT_SERVICE.usp_docMulti_INSERT(
//                            lastGeneratedId,
//                            ref_candidato_id,
//                            ref_materia_id,
//                            actual_abstract,//   actual abstract; ONLY in last chunk.
//                            fname,// sourceName
//                            docBody,//--- current chunk ---------------
//                            ref newId,
//                            null // trx
//                        );
//                    lastGeneratedId = newId;// non e' eliminabile: il retval e' gia' occupato dall'insertionProxyResult.
//                    //
//                    if (0 >= lastGeneratedId
//                        || 0 != insertionProxyResult)
//                    {
//                        throw new System.Exception("inserimento fallito per chunk di doc_multi.");
//                    }
//                    // else// insertion ok, and id_identity generated valid.
//                    docBody = null;// Garbage Collect.
//                }
//                ////----DON'T dispose transaction: each insertion is wrapped with a get_max(id) in a stored-transacion. ---------
//                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
//                    "Il documento e' stato pubblicato. Utilizzare le parole chiave dell'abstract per ricercarlo."
//                    + " lastGeneratedId =" + lastGeneratedId.ToString()
//                    + " abstract =" + actual_abstract.ToString(),
//                    0);
//            }//----end try
//            catch (System.Exception ex)
//            {
//                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
//                    "Eccezione nell'inserimento di un doc_multi. ex= "
//                    + ex.Message
//                    + ". L' abstract era = " + actual_abstract,
//                    0);
//            }
//            finally
//            {
//                if (null != theStream)
//                {
//                    theStream.Close();
//                    theStream = null;//---garbage collect.-----
//                }// else already ok.-------
//            }
//            // ready.
//            return lastGeneratedId;// >0 means success.
//        }//------- end /// input into the db.







//        /// <summary>
//        /// this is the unique access point to extract documents. Flow:
//        ///     - it queries an Entity_materie::Proxy and extracts the blob
//        ///     - saves on the original filename, at the User::tmp path, decorating with a dynamic string( time based).
//        /// </summary>
//        /// <param name="id"> the id-field, in the db record layout.</param>
//        /// <returns>
//        /// a status integer:
//        ///     0==success,
//        ///     -1==failure.
//        /// </returns>
//        public Int32 FILE_from_DB_writeto_FS(
//            int id,
//            out string extractionFullPath
//            , string clientIP
//          )
//        {
//            extractionFullPath = null;// compulsory init; actual initialization in body.
//            if (0 >= id)
//            {// invalid id.
//                return -1;
//            }// else can continue.
//            //
//            System.IO.FileStream multiChunk_stream = null;
//            //
//            try
//            {
//                System.Data.DataSet ds_allInvolvedIds =
//                    Entity_materie.Proxies.usp_docMulti_dataMining_SERVICE.usp_docMulti_dataMining(id);
//                if (null == ds_allInvolvedIds) throw new System.Exception("trouble connecting to database.");
//                //
//                //----revert the ids to their original order.--------
//                hm_ids = ds_allInvolvedIds.Tables.Count;
//                if (0 >= hm_ids
//                    || 0 >= ds_allInvolvedIds.Tables[1].Rows.Count)// NB Tables[0] is static; doesn't count.
//                {// invalid id.
//                    return -1;
//                }// else can continue.
//                else// valid chunk group.
//                {
//                    ids = new Int32[hm_ids];
//                    for (int c = 0; c < hm_ids; c++)
//                    {
//                        ids[c] = (Int32)(ds_allInvolvedIds.Tables[hm_ids - (c + 1)].Rows[0].ItemArray[0]);
//                    }
//                    string sourceName = null;
//                    System.Data.DataTable dt_sourceName =
//                        Entity_materie.Proxies.usp_docMulti_get_sourceName_SERVICE.usp_docMulti_get_sourceName(
//                            ids[1]//--NB. skip first datatable row, which has id==0.
//                    );
//                    if (null != dt_sourceName
//                        && 0 < dt_sourceName.Rows.Count)
//                    {
//                        sourceName = (string)(dt_sourceName.Rows[0].ItemArray[0]);
//                        if (sourceName.Length > 60)
//                        {
//                            int last_dot_position = sourceName.LastIndexOf('.');
//                            string extension = ".doc";// default
//                            if (-1 < last_dot_position)
//                            {
//                                extension = sourceName.Substring(
//                                    last_dot_position, 4);
//                            }
//                            // else  default to "doc".
//                            sourceName = sourceName.Substring(0, 56) + extension;
//                        }// else leave it as is.
//                    }
//                    else
//                    {// invalid id.
//                        return -1;
//                    }// else can continue.
//                    //
//                    ConfigurationLayer.ConfigurationService cs = new
//                        ConfigurationLayer.ConfigurationService("FileTransferTempPath/fullpath");
//                    string dlgSave_InitialDirectory = cs.GetStringValue("path");
//                    //-Gestione dismessa --- NB. it's different for every user, included ASPNETusr ---------
//                    //-Gestione dismessa string dlgSave_InitialDirectory = Environment.GetEnvironmentVariable("tmp", EnvironmentVariableTarget.User);
//                    //-Gestione dismessa string dlgSave_InitialDirectory = @"C:\root\LogSinkFs\cv";// TODO adapt to the server file sysetm.
//                    dlgSave_InitialDirectory += "\\download";// from server to client.
//                    //
//                    // Ensure the folder exists
//                    if (!System.IO.Directory.Exists(dlgSave_InitialDirectory))
//                    {
//                        System.IO.Directory.CreateDirectory(dlgSave_InitialDirectory);
//                    }// else already present on the web server file system.
//                    extractionFullPath =
//                        dlgSave_InitialDirectory
//                        + "\\"
//                        + DateTime.Now.Year.ToString()
//                        + DateTime.Now.Month.ToString()
//                        + DateTime.Now.Day.ToString()
//                        .Replace('/', '_').Replace('\\', '_')
//                        .Replace(' ', '_').Replace('.', '_').Replace(':', '_')
//                        .Replace(';', '_').Replace(',', '_')
//                        + "_"
//                        + sourceName;
//                    if (null == clientIP || "" == clientIP)
//                    {
//                        clientIP = " unspecified. ";
//                    }// else continue.
//                    LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
//                        " extractionFullPath = " + extractionFullPath
//                        + " _ clientIP = " + clientIP
//                        , 0);
//                    //--prepare the binary stream to append to.-----------
//                    multiChunk_stream = new System.IO.FileStream(
//                        extractionFullPath,
//                        System.IO.FileMode.Append,
//                        System.IO.FileAccess.Write,
//                        System.IO.FileShare.None,
//                        docBody__Length * hm_ids// prepare a size of "n" chunks of 64Kb. The last one is generally not full: so it's surely enough.
//                    );
//                    if (null == multiChunk_stream) throw new System.Exception("unable to write the file.");
//                    //---retrieve blob, foer each id.---------------------
//                    for (int c = 1; c < hm_ids; c++)//--NB. skip first datatable row, which has id==0.
//                    {
//                        System.Data.DataTable dt_currentChunk =
//                            Entity_materie.Proxies.usp_docMulti_getBlobAtId_SERVICE.usp_docMulti_getBlobAtId(
//                                ids[c]
//                        );
//                        byte[] tmp_chunk = (byte[])(dt_currentChunk.Rows[0]["doc"]);
//                        multiChunk_stream.Write(//NB.----write a single chunk on filesystem.----------------------
//                            tmp_chunk,
//                            0,
//                            tmp_chunk.Length
//                        );
//                    }// end for
//                    LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
//                        "OK, doc extracted.",
//                        0);
//                }// end else// valid chunk group.
//            }// end try.---
//            catch (System.Exception ex)// invalid id inserted
//            {
//                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
//                    "error while trying to retrieve a document: " + ex.Message,
//                    0);
//            }
//            finally
//            {
//                ids = null;// reset.
//                hm_ids = -1;// reset.
//                if (null != multiChunk_stream)
//                {
//                    multiChunk_stream.Flush();
//                    multiChunk_stream.Close();
//                    multiChunk_stream = null;//---garbage collect.-----
//                }//----------else already ok.----
//            }
//            //---ready---
//            return 0;// means success.
//        }//---end method----





//        #endregion data_IO



//    }// end class
//}// end nmsp

#endregion cantina
