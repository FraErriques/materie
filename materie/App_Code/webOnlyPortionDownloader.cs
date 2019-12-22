using System;
using System.Text;


 
    public static class webOnlyPortionDownloader_SERVICE
    {


        public static void webOnlyPortionDownloader(
            Int32 id_doc_multi
            ,System.Web.HttpContext this_Context
            )
        {
            string webServer_extractionPath;// get it in "out" from Process::
            string filename;// get it in "out" from Process::
            Process_materie.documento.downloader_service.downloader(
                id_doc_multi
                , this_Context.Request.UserHostName  //"client_IP"
                , out webServer_extractionPath
                , out filename
            );
            //
            // portare in download dal web server al client.
            //
            //// extract extension
            //int extIndex = webServer_extractionPath.LastIndexOf('.');
            //string extension = "doc";
            //if (-1 < extIndex)
            //{
            //    extension = webServer_extractionPath.Substring(extIndex);
            //}// else let it default.
            ////
            ////
            //this_Context.Response.ContentType = webOnlyPortionDownloader_SERVICE.setContentType(extension);
            ////
            // Set the filename
            this_Context.Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            //
            // Stream the file from web_Server to the client filesystem( the client browser will show a dialog).
            this_Context.Response.WriteFile(webServer_extractionPath + "\\" + filename);
            // ready.
        }// end method download_from_webServer_to_Client.





        /// <summary>
        /// Set the content type, based on extension.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns>the MIME type</returns>
        public static string setContentType(string extension)
        {
            if (
                null == extension
                || "" == extension.Trim()
                )
            {
                throw new System.Exception("invalid extension.");
            }// else continue.
            string the_MIME_type = null;
            //
            string clean_extension = extension.Trim().ToLower();
            switch (clean_extension)
            {
                case ".c":
                case ".txt":
                    {
                        the_MIME_type = "text/plain";
                        break;
                    }
                case ".jpg":
                case ".jpeg":
                    {
                        the_MIME_type = "image/jpeg";
                        break;
                    }
                case ".pdf":
                    {
                        the_MIME_type = "application/pdf";
                        break;
                    }
                case ".xls":
                    {
                        the_MIME_type = "application/msexcel";
                        break;
                    }
                case ".ppt":
                case ".pps":
                    {
                        the_MIME_type = "application/powerpoint";
                        break;
                    }
                case ".doc":
                    {
                        the_MIME_type = "application/msword";
                        break;
                    }
                //-------------------------------------------------------goto Browser ----------------
                default://-----------------------------------------------goto Browser ----------------
                case ".htm":
                case ".html":
                case ".htmls":
                case ".htx":
                case ".mht":
                    {
                        the_MIME_type = "text/html";
                        break;
                    }
            }// end switch
            // ready.
            return the_MIME_type;
        }//



    }// class

 