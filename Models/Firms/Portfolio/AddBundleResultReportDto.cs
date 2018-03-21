using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class AddBundleResultReportDto
    {
        public string                       ProcessId           { get; set; }
        public List<FirmPortfolioDto>       PortofliosCreated   { get; set; }
        public List<AddBundleErrorDto>      Errors              { get; set; }
        public TimeSpan                     TotalTimeToProcess  { get; set; }
        public List<AddBundleApiCallDto>    ApiCalls            { get; set; }


        private readonly Stopwatch _stopwatch;

        public AddBundleResultReportDto(string processId)
        {
            ProcessId = processId;
            PortofliosCreated = new List<FirmPortfolioDto>();
            Errors = new List<AddBundleErrorDto>();
            ApiCalls = new List<AddBundleApiCallDto>();

            _stopwatch=new Stopwatch();
        }


        public void AddApiCall(string name)
        {
            var item = ApiCalls.FirstOrDefault(a => a.Name == name);

            if (item == null)
            {
                ApiCalls.Add(new AddBundleApiCallDto
                {
                    Name = name,
                    TotalCalls = 1
                });
                return;
            }

            var index = ApiCalls.IndexOf(item);
            ApiCalls[index].TotalCalls++;
        }


        public void Start()
        {
            _stopwatch.Start();
        }


        public void End()
        {
            _stopwatch.Stop();

            TotalTimeToProcess = _stopwatch.Elapsed;
        }



    }
}
