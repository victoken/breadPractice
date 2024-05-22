namespace breadPractice.Models
{
    /// <summary>
    /// 種類 
    /// </summary>
    public class Categories
    {
        /// <summary>
        /// 種類編號 
        /// </summary>
        public int CategoryID {  get; set; }
        /// <summary>
        /// 種類名稱 
        /// </summary>
        public string ?CategoryName { get; set; }
        /// <summary>
        /// 說明 
        /// </summary>
        public string ?Description { get; set; }
    }
}
