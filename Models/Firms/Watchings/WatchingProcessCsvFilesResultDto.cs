using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Firms.Watchings
{
    public class WatchingProcessCsvFilesResultDto
    {
        private readonly string _compressedFileName;
        
        public List<WatchingProcessCsvFilesError>       Errors          { get; set; }
        public List<WatchingProcessCsvFileProcessed>    ProcessedFiles  { get; set; }
        
        #region Constructor

        public WatchingProcessCsvFilesResultDto(string compressedFileName)
        {
            _compressedFileName = compressedFileName;
            
            Errors = new List<WatchingProcessCsvFilesError>();
            ProcessedFiles = new List<WatchingProcessCsvFileProcessed>();
        }

        #endregion

        #region Helpers

        public void AddError(string csvFileName, int lineNumber, string message)
        {
            Errors.Add(new WatchingProcessCsvFilesError
            {
                CompressedFileName = _compressedFileName,
                CsvFileName = csvFileName,
                LineNumber = lineNumber,
                Message = message
            });
        }
        
        public void AddProcessedLine(string fileName, string message)
        {
            var index = ProcessedFiles.FindIndex(m => m.CompressedFileName == _compressedFileName && m.CsvFileName == fileName);
            if (index < 0)
            {
                ProcessedFiles.Add(new WatchingProcessCsvFileProcessed
                {
                    CompressedFileName = _compressedFileName,
                    Messages = new List<string> { message },
                    CsvFileName = fileName,
                    LinesProcessed = 1
                });
                return;
            }

            ProcessedFiles[index].Messages.Add(message);
            ProcessedFiles[index].LinesProcessed++;
        }

        #endregion

    }
}