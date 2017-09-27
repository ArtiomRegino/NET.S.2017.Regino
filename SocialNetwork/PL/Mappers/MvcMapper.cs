using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using PL.Models.Profile;
using PL.Models.Search;

namespace PL.Mappers
{
    public static class MvcMapper
    {
        public static PresentationOfProfileViewModel ToPresentation(this BllProfile bllProfile)
        {
            var profile = new PresentationOfProfileViewModel
                                     {
                                         Id = bllProfile.Id,
                                         AboutMe = bllProfile.AboutMe,
                                         BirthDate = bllProfile.BirthDate,
                                         City = bllProfile.City,
                                         ContactPhone = bllProfile.ContactPhone,
                                         FirstName = bllProfile.FirstName,
                                         Gender = bllProfile.Gender,
                                         LastName = bllProfile.LastName,
                                         PhotoId = bllProfile.PhotoId,
                                         Username = bllProfile.UserName
                                     };

            return profile;
        }

        public static IEnumerable<PresentationOfProfileViewModel> ToPresentations(this IEnumerable<BllProfile> bllProfiles)
        {
            return bllProfiles.Select(profile => profile.ToPresentation()).ToList();
        }

        public static SearchResultViewModel ToSearchResultModel(this BllProfile bllProfile)
        {
            var profile = new SearchResultViewModel
            {
                Id = bllProfile.Id,
                FirstName = bllProfile.FirstName,
                LastName = bllProfile.LastName,
                PhotoId = bllProfile.PhotoId,
                Username = bllProfile.UserName
            };

            return profile;
        }

        public static IEnumerable<SearchResultViewModel> ToSearchResultModel(this IEnumerable<BllProfile> bllProfiles)
        {
            return bllProfiles.Select(profile => profile.ToSearchResultModel()).ToList();
        }

        public static FullSearchViewModel ToFullSearchModel(this BllProfile bllProfile)
        {
            var profile = new FullSearchViewModel
            {
                Id = bllProfile.Id,
                BirthDate = bllProfile.BirthDate,
                City = bllProfile.City,
                FirstName = bllProfile.FirstName,
                Gender = bllProfile.Gender,
                LastName = bllProfile.LastName,
                Username = bllProfile.UserName
            };

            return profile;
        }

        public static IEnumerable<FullSearchViewModel> ToFullSearchModel(this IEnumerable<BllProfile> bllProfiles)
        {
            return bllProfiles.Select(profile => profile.ToFullSearchModel()).ToList();
        }
    }
}