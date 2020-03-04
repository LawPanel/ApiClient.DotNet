using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FilterByTemplateFieldsDto
    {
        public List<FilterByTemplateFieldsTemplateDto> Templates { get; set; }

        public FilterByTemplateFieldsDto()
        {
            Templates = new List<FilterByTemplateFieldsTemplateDto>();
        }
    }

    public class FilterByTemplateFieldsTemplateDto
    {
        public Guid                                     Id          { get; set; }
        public List<FilterByTemplateFieldsComponentDto> Components  { get; set; }

        public FilterByTemplateFieldsTemplateDto()
        {
            Components = new List<FilterByTemplateFieldsComponentDto>();
        }
    }


    public class FilterByTemplateFieldsComponentDto
    {
        public Guid                                 Id      { get; set; }
        public List<FilterByTemplateFieldsValueDto> Values  { get; set; }

        public FilterByTemplateFieldsComponentDto()
        {
            Values = new List<FilterByTemplateFieldsValueDto>();
        }
    }

    public class FilterByTemplateFieldsValueDto
    {
        public string Comparator    { get; set; }
        public string Operator      { get; set; }
        public string Value         { get; set; }
        public string Visible       { get; set; }
    }
}
