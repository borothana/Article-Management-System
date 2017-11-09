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
        #region "Info"
        Info GetInfoById(int infoId);
        List<Info> GetInfoList();
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
        List<Story> GetStoryByUser(string userId);
        Story GetStoryById(int storyId);
        bool ApproveStory(int storyId);
        bool DenyStory(int storyId, string feedback);
        StoryVM GetStoryVMById(int storyId);
        int AddStory(StoryVM storyVM);
        bool UpdateStory(StoryVM storyVM);
        bool DeleteStory(int StoryId);
        #endregion

        #region "User"
        List<User> GetUserList();
        UserVM GetUserVMById(string userId);
        UserVMEdit GetUserVMEditById(string userId);
        User GetUserById(string userId);
        User GetUserByUserName(string userName);
        List<User> GetUserListByRole(string role);
        string AddUser(UserVM user, string role);
        Task<bool> DeactivateUser(string userId);
        Task<bool> ReactivateUser(string userId);
        bool ChangePassword(string userId, string currentPassword, string newPassword);
        Task<bool> UpdateUser(UserVM user, string role);
        bool UpdateUser(UserVMEdit user, string role);
        Task<bool> DeleteUser(string userId);
        Task<bool> Login(string userId, string password);
        #endregion

        #region "Blog"
        List<Blog> GetBlogList();
        Blog GetBlogById(int id);
        int AddBlog(Blog blog);
        bool UpdateBlog(Blog blog);
        bool DeleteBlog(int id);
        #endregion
    }
}
