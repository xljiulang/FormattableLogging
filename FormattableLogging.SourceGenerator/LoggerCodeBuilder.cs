using Microsoft.CodeAnalysis.Text;
using System.IO;
using System.Text;

namespace FormattableLogging.SourceGenerator
{
    /// <summary>
    /// HttpApi代码构建器
    /// </summary>
    sealed class LoggerCodeBuilder  
    {
        private readonly string nameSpace;

        /// <summary>
        /// HttpApi代码构建器
        /// </summary>
        /// <param name="nameSpace"></param>
        public LoggerCodeBuilder(string nameSpace)
        {
            this.nameSpace = nameSpace;
        }

        /// <summary>
        /// 转换为SourceText
        /// </summary>
        /// <returns></returns>
        public SourceText ToSourceText()
        {
            var code = this.ToString();
            return SourceText.From(code, Encoding.UTF8);
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var name = $"{this.GetType().Namespace}.LoggerExtensions.cs";
            var stream = this.GetType().Assembly.GetManifestResourceStream(name);
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd().Replace("@namespace", this.nameSpace);
            }
        } 
    }
}
