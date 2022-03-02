using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace FormattableLogging.SourceGenerator
{
    /// <summary>
    /// httpApi语法接收器
    /// </summary>
    sealed class LoggerSyntaxReceiver : ISyntaxReceiver
    {
        /// <summary>
        /// 接口列表
        /// </summary>
        private readonly List<NamespaceDeclarationSyntax> syntaxNodeList = new List<NamespaceDeclarationSyntax>();

        /// <summary>
        /// 访问语法树 
        /// </summary>
        /// <param name="syntaxNode"></param>
        void ISyntaxReceiver.OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is NamespaceDeclarationSyntax namespaceDeclaration)
            {
                this.syntaxNodeList.Add(namespaceDeclaration);
            }
        }

        /// <summary>
        /// 获取所有根空间
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetRootNamespaces()
        {
            var hashSet = new HashSet<string>();
            foreach (var node in this.syntaxNodeList)
            {
                var @namespace = node.Name.ToString();
                var index = @namespace.IndexOf('.');
                if (index >= 0)
                {
                    @namespace = @namespace.Substring(0, index);
                }
                hashSet.Add(@namespace);
            }
            return hashSet;
        }
    }
}