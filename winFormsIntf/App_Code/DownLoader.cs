//using System;
//using System.Data;
//using System.Configuration;


///// <summary>
///// AppCode::Downloader
///// </summary>
//public static class Downloader
//{



//    public static void DownloadButton_Click(
//        Int32 id_doc_multi
//        ,out string extractionPath
//        )
//    {
//        // query for blob at id, by means of Entity_materie::Doc_multi.
//        Entity_materie.BusinessEntities.docMulti dm = new Entity_materie.BusinessEntities.docMulti();
//        string webServer_extractionPath = null;
//        Int32 downloadResult =
//            dm.FILE_from_DB_writeto_FS(
//                id_doc_multi
//                ,out webServer_extractionPath // sul web server.
//                ,"localhost"//par IP. Here calling the Entity::Proxy from localhost. When called from a web-client this parameter gets relevant.
//            );
//        // Ensure that Entity_materie::Doc_multi produced an actual file.
//        if (
//            0 != downloadResult
//            || string.IsNullOrEmpty(webServer_extractionPath)
//            || !System.IO.File.Exists(webServer_extractionPath)
//          )
//        {
//            // throw new HttpException(404, "doc_multi not found"); HTTP version
//            throw new System.Exception( "Exception : docMulti not found.");
//        }// else trace client credentials.
//        else
//        {
//            LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
//                " document extracted at client path: " + webServer_extractionPath
//                , 5);// kkep this tracing-importance-level high, so that it's not cut off when excluding unnecessary logs.
//        }
//        // extract filename
//        int fnameIndex = webServer_extractionPath.LastIndexOf('\\');// it's a reserved char: double it.
//        string filename = webServer_extractionPath.Substring(fnameIndex + 1);// exclude the last backslash.
//        // NB. output par crucial for caller. I need the path only; so remove the filename.
//        extractionPath = webServer_extractionPath.Remove( webServer_extractionPath.LastIndexOf('\\') );
//        // l'application server su localhost ha scritto il file in: extractionPath\filename
//        // ready.
//    }// end method DownloadButton_Click versione localhost (i.e. NO HTTP).




//    # region cantina

//    ///// <summary>
//    ///// Set the content type, based on extension.
//    ///// </summary>
//    ///// <param name="extension"></param>
//    ///// <returns>the MIME type</returns>
//    //public static string setContentType(string extension)
//    //{
//    //    if (
//    //        null == extension
//    //        || "" == extension.Trim()
//    //        )
//    //    {
//    //        throw new System.Exception("invalid extension.");
//    //    }// else continue.
//    //    string the_MIME_type = null;
//    //    //
//    //    string clean_extension = extension.Trim().ToLower();
//    //    switch (clean_extension)
//    //    {
//    //        case ".c":
//    //        case ".txt":
//    //            {
//    //                the_MIME_type = "text/plain";
//    //                break;
//    //            }
//    //        case ".jpg":
//    //        case ".jpeg":
//    //            {
//    //                the_MIME_type = "image/jpeg";
//    //                break;
//    //            }
//    //        case ".pdf":
//    //            {
//    //                the_MIME_type = "application/pdf";
//    //                break;
//    //            }
//    //        case ".xls":
//    //            {
//    //                the_MIME_type = "application/msexcel";
//    //                break;
//    //            }
//    //        case ".ppt":
//    //        case ".pps":
//    //            {
//    //                the_MIME_type = "application/powerpoint";
//    //                break;
//    //            }
//    //        case ".doc":
//    //            {
//    //                the_MIME_type = "application/msword";
//    //                break;
//    //            }
//    //        //-------------------------------------------------------goto Browser ----------------
//    //        default://-----------------------------------------------goto Browser ----------------
//    //        case ".htm":
//    //        case ".html":
//    //        case ".htmls":
//    //        case ".htx":
//    //        case ".mht":
//    //            {
//    //                the_MIME_type = "text/html";
//    //                break;
//    //            }
//    //    }// end switch
//    //    // ready.
//    //    return the_MIME_type;
//    //}//



//    ///// <summary>
//    ///// on keywords research
//    ///// </summary>
//    ///// <param name="sender"></param>
//    ///// <param name="e"></param>
//    //public static System.Data.DataTable btnKeywords_Click(
//    //    string this_txtKeywords_Text
//    //    )
//    //{
//    //    System.Data.DataTable plausibleDocuments =
//    //        Process_materie.doc_multi.doc_multi_searchingEngines.SearchByKeywordsOnAbstracts(
//    //            this_txtKeywords_Text
//    //        );
//    //    return plausibleDocuments;
//    //}//



//    # endregion cantina


//}// end class
