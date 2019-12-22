using System;
using System.Collections.Generic;
using System.Text;

namespace Process_materie.documento
{
    public static class downloader_service
    {



        /// <summary>
        /// 
        /// L'oggetto Downloader e' proprio dell'interfaccia in cui ha luogo: la versione web e quella localhost ne hanno due
        /// implementazioni diverse. In maniera che sembra non aggirabile, in quanto la versione web deve far ricorso a Request
        /// e Response per far transitare i pacchetti. Non sembra dunque possibile una versione unificata.
        /// Sarebbe pero' possibile mettere in Process le due versioni Downloader_Web e Downloader_localhost
        /// con le rispettive implementazioni.
        /// Al 22/12/2019 è in atto un tentativo di mettere in Process:: a fattore comune, la parte qui presente.
        /// La versione HTTP ha un wrapper che aggiunge le azioni specifiche del protocollo, dopo la chiamata presente.
        /// 
        /// </summary>
        /// <param name="id_doc_multi"></param>
        /// <param name="clientIP"></param>
        /// <param name="extractionPath"></param>
        public static void downloader(
            Int32 id_doc_multi
            ,string clientIP
            ,out string extractionPath
            ,out string filename
        )
        {
            // query for blob at id, by means of Entity_materie::Doc_multi.
            Entity_materie.BusinessEntities.docMulti dm = new Entity_materie.BusinessEntities.docMulti();
            string webServer_extractionPath = null;
            Int32 downloadResult =
                dm.FILE_from_DB_writeto_FS(
                    id_doc_multi
                    , out webServer_extractionPath // sul web server.
                    , clientIP // just for logging purposes
                );
            // Ensure that Entity_materie::Doc_multi produced an actual file.
            if (
                0 != downloadResult
                || string.IsNullOrEmpty(webServer_extractionPath)
                || !System.IO.File.Exists(webServer_extractionPath)
              )
            {
                // throw new HttpException(404, "doc_multi not found"); HTTP version
                throw new System.Exception("Exception : docMulti not found.");
            }// else trace client credentials.
            else
            {
                LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                    " document extracted at client path: " + webServer_extractionPath
                    , 5);// kkep this tracing-importance-level high, so that it's not cut off when excluding unnecessary logs.
            }
            // extract filename
            int fnameIndex = webServer_extractionPath.LastIndexOf('\\');// it's a reserved char: double it.
            filename = webServer_extractionPath.Substring(fnameIndex + 1);// exclude the last backslash.
            // NB. output par crucial for caller. I need the path only; so remove the filename.
            extractionPath = webServer_extractionPath.Remove(webServer_extractionPath.LastIndexOf('\\'));
            // l'application server su localhost ha scritto il file in: extractionPath\filename
            // ready.
        }// this version should be enough from localhost; the HTTP version has a wrapper that adds the HTTP.actions after this call.


    }// class

}// nmsp
