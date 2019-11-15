using System;
using System.Collections.Generic;
using System.Text;

namespace Process_materie.documento
{
    public static class downloader
    {



        public static void DownloadButton_Click(
            Int32 id_doc_multi
            )
        {
            // query for blob at id, by means of Entity_materie::Doc_multi.
            Entity_materie.BusinessEntities.docMulti dm = new Entity_materie.BusinessEntities.docMulti();
            string client_extractionPath = null;
            Int32 res =
                dm.FILE_from_DB_writeto_FS(
                    id_doc_multi,
                    out client_extractionPath // sull'application server.
                    , "localhost : ApplicationPlatform."
                );
            //
            // Ensure that Entity_materie::Doc_multi produced an actual file.
            if (
                string.IsNullOrEmpty(client_extractionPath)
                || !System.IO.File.Exists(client_extractionPath)
              )
            {
                throw new System.Exception("document not found");
            }// else trace client credentials.
            else
            {
                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                    " document extracted by client: "
                    + "localhost : ApplicationPlatform."
                    + "  "
                    , 5);
            }
            //
            // portare in download dal web server al client.
            //
            // extract extension
            int extIndex = client_extractionPath.LastIndexOf('.');
            string extension = "doc";
            if (-1 < extIndex)
            {
                extension = client_extractionPath.Substring(extIndex);
            }// else let it default.
            //
            // extract filename
            int fnameIndex = client_extractionPath.LastIndexOf('\\');// it's a reserved char: double it.
            string filename = client_extractionPath.Substring(fnameIndex + 1);// exclude the last backslash.
            //
            //this_Context.Response.ContentType = downloader.setContentType(extension);
            //
            // Set the filename
            //this_Context.Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            //
            // Stream the file from web_Server to the client filesystem( the client browser will show a dialog).
            //this_Context.Response.WriteFile(client_extractionPath);
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
        }// end setContentType



    }// class

}// nmsp
