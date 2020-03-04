using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.UserInputs
{
    public class UserInputCreateDto : Dto
    {
        public Guid                                     UserInputTemplateId { get; set; }
        public Guid?                                    UserId              { get; set; }
        public Guid                                     ClientId            { get; set; }
        public string                                   Notes               { get; set; }
        public List<UserInputComponentCreateUpdateDto>  Components          { get; set; }

        public UserInputCreateDto()
        {
            Components = new List<UserInputComponentCreateUpdateDto>();
        }
    }
}
