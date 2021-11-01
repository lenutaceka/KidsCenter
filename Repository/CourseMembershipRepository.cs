using KidsCenter.Models;
using KidsCenter.Models.DbObjects;
using KidsCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenter.Repository
{
    public class CourseMembershipRepository
    {
        private KidsCenterModelsDataContext dbContext;

        public CourseMembershipRepository()
        {
            dbContext = new KidsCenterModelsDataContext();
        }

        public CourseMembershipRepository(KidsCenterModelsDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<CourseMembershipModel> GetAllMemberships()
        {
            List<CourseMembershipModel> CourseMembershipList = new List<CourseMembershipModel>();
            foreach (CourseMembership dbCourseMembership in dbContext.CourseMemberships)
            {
                CourseMembershipList.Add(MapDbObjectToModel(dbCourseMembership));
            }
            return CourseMembershipList;
        }

        public List<CourseMembershipViewModel> GetAllMembershipsVM()
        {
            List<CourseMembershipViewModel> courseMembershipVM = new List<CourseMembershipViewModel>();
            List<CourseMembershipModel> courseMembership = GetAllMemberships();

            for (var i = 0; i < courseMembership.Count; i++)
            {
                courseMembershipVM.Add(new CourseMembershipViewModel());
                courseMembershipVM[i].MembershipID = courseMembership[i].MembershipId;
                courseMembershipVM[i].CourseCategoryId = dbContext.Courses.FirstOrDefault(x => x.CourseId == courseMembership[i].CourseId).CourseCategoryId;
                courseMembershipVM[i].FirstName = dbContext.Childrens.FirstOrDefault(x => x.ChildId == courseMembership[i].ChildId).FirstName;
                courseMembershipVM[i].LastName = dbContext.Childrens.FirstOrDefault(x => x.ChildId == courseMembership[i].ChildId).LastName;
                courseMembershipVM[i].Email = dbContext.Childrens.FirstOrDefault(x => x.ChildId == courseMembership[i].ChildId).Email;
                courseMembershipVM[i].StartDate = courseMembership[i].StartDate;
                courseMembershipVM[i].EndDate = courseMembership[i].EndDate;
            }
            return courseMembershipVM;
        }

        public CourseMembershipModel GetMembershipByID(int id)
        {
            return MapDbObjectToModel(dbContext.CourseMemberships.FirstOrDefault(x => x.MembershipId == id));
        }

        public void InsertMembership(CourseMembershipModel courseMembershipModel)
        {
            dbContext.CourseMemberships.InsertOnSubmit(MapModelToDbObject(courseMembershipModel));
            dbContext.SubmitChanges();
        }


        public void UpdateMembership(CourseMembershipModel courseMembershipModel)
        {
            CourseMembership courseMembership = dbContext.CourseMemberships.FirstOrDefault(x => x.MembershipId == courseMembershipModel.MembershipId);
            if (courseMembership != null)
            {
                courseMembership.MembershipId = courseMembershipModel.MembershipId;
                courseMembership.CourseId = courseMembershipModel.CourseId;
                courseMembership.ChildId = courseMembershipModel.ChildId;
                courseMembership.StartDate = courseMembershipModel.StartDate;
                courseMembership.EndDate = courseMembershipModel.EndDate;
                dbContext.SubmitChanges();
            }
        }


        public void DeleteMembership(int id)
        {
            CourseMembership courseMembership = dbContext.CourseMemberships.FirstOrDefault(x => x.MembershipId == id);
            if (courseMembership != null)
            {
                dbContext.CourseMemberships.DeleteOnSubmit(courseMembership);
                dbContext.SubmitChanges();
            }
        }

        private CourseMembershipModel MapDbObjectToModel(CourseMembership dbCourseMembership)
        {
            CourseMembershipModel courseMembershipModel = new CourseMembershipModel();
            if (dbCourseMembership != null)
            {
                courseMembershipModel.MembershipId = dbCourseMembership.MembershipId;
                courseMembershipModel.CourseId = dbCourseMembership.CourseId;
                courseMembershipModel.ChildId = dbCourseMembership.ChildId;
                courseMembershipModel.StartDate = dbCourseMembership.StartDate;
                courseMembershipModel.EndDate = dbCourseMembership.EndDate;

                return courseMembershipModel;
            }
            return null;
        }

        private CourseMembership MapModelToDbObject(CourseMembershipModel courseMembershipModel)
        {
            CourseMembership dbCourseMembership = new CourseMembership();
            if (courseMembershipModel != null)
            {
                dbCourseMembership.MembershipId = courseMembershipModel.MembershipId;
                dbCourseMembership.CourseId = courseMembershipModel.CourseId;
                dbCourseMembership.ChildId = courseMembershipModel.ChildId;
                dbCourseMembership.StartDate = courseMembershipModel.StartDate;
                dbCourseMembership.EndDate = courseMembershipModel.EndDate;

                return dbCourseMembership;
            }
            return null;
        }
    }
}