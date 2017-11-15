using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Models.ViewModels;

namespace SCMS.Models.Interface
{
    public interface ISCMS
    {
        Response ReturnSuccess();
        #region "Info"
        Info GetInfoById(int infoId);
        List<Info> GetInfoList();
        List<Info> GetCurrentInfo();
        List<Info> GetInfoByDate(DateTime FD, DateTime TD);
        int AddInfo(Info info);
        bool UpdateInfo(Info info);
        bool DeleteInfo(int infoId);
        #endregion

        #region "Category"
        Category GetCategoryById(int categoryId);
        List<Category> GetCategoryList();
        int AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryId);
        #endregion

        #region "Intimacy"
        Intimacy GetIntimacyById(int itimacyId);
        List<Intimacy> GetIntimacyList();
        int AddIntimacy(Intimacy intimacy);
        bool UpdateIntimacy(Intimacy intimacy);
        bool DeleteIntimacy(int intimacyId);
        #endregion

        #region "Hashtag"
        List<Hashtag> GetHashtagList();
        Hashtag GetHashtagById(int hastagId);
        Hashtag GetHashtagByDesc(string description);
        List<Hashtag> GetHashtagByStory(int storyId);
        int AddHashtag(Hashtag hashtag);
        bool AddHashtagByStory(Story story);
        bool UpdateHashtag(Hashtag hashtag);
        bool DeleteHashtagById(int hashtagId);
        bool DeleteHashtagByStory(int storyId);
        #endregion

        #region "Comment"
        Comment GetCommentById(int commentId);
        List<Comment> GetCommentByStory(int storyId);
        List<Comment> GetCommentList();
        int AddComment(Comment comment);
        bool UpdateComment(Comment comment);
        bool DeleteCommentById(int commentId);
        bool DeleteCommentByStory(int storyId);
        #endregion

        #region "Story"
        List<Story> GetStoryList();
        List<Story> GetStoryForHome(List<int> categorySelected, List<int> intimacySelected, string title, string hashTag);
        List<StoryVM> GetStoryByStatus(char type);
        List<Story> GetStoryByUserId(string userId);
        Story GetStoryById(int storyId);
        bool ApproveStory(int storyId, string feedback);
        bool DenyStory(int storyId, string feedback);
        StoryVM GetStoryVMById(int storyId);
        int AddStory(StoryVM storyVM);
        bool UpdateStory(StoryVM storyVM);
        bool DeleteStory(int StoryId);
        List<StoryVM> GetStoryVMByUserId(string userId);
        StoryVM ConvertStoryToVM(Story story);
        #endregion

        #region "User"
        List<User> GetUserList();
        User GetUserById(string userId);
        UserVM GetUserVMByUserName(string userName);
        User GetUserByUserName(string userName);
        List<User> GetUserListByRole(string role);
        UserVM AddUser(UserVM user, string role);
        bool DeactivateUser(string userId);
        bool ReactivateUser(string userId);
        bool ChangePassword(string userId, string currentPassword, string newPassword);
        UserVM UpdateUser(UserVM user, string role);
        bool DeleteUser(string userId);
        bool Login(string userId, string password);
        bool Logout();
        User ConvertVMToUser(UserVM input);
        UserVM ConvertUserToVM(User input);
        #endregion        
    }
}
