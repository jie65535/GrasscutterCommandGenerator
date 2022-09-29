using GrasscutterTools.Models;

namespace GrasscutterTools.Interfaces
{
    /// <summary>
    /// 带列表的页面接口
    /// </summary>
    public interface IPageListProvider
    {
        /// <summary>
        /// 列表项选中时触发
        /// </summary>
        /// <param name="item">列表项</param>
        void OnListItemSelected(GameItem item);

        /// <summary>
        /// 列表源
        /// </summary>
        GameItems ListSource { get; }

        /// <summary>
        /// 是否可以分组
        /// </summary>
        bool CanGroup { get; }

        /// <summary>
        /// 类别
        /// </summary>
        string[] Categories { get; }
    }
}
