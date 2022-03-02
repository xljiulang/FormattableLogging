using Microsoft.CodeAnalysis;

namespace FormattableLogging.SourceGenerator
{
    /// <summary>
    /// Logger代码生成器
    /// </summary>
    [Generator]
    public class LoggerSourceGenerator : ISourceGenerator
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new LoggerSyntaxReceiver());
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is LoggerSyntaxReceiver receiver)
            {
               // System.Diagnostics.Debugger.Launch();
                foreach (var @namespace in receiver.GetRootNamespaces())
                {
                    var builder = new LoggerCodeBuilder(@namespace);
                    context.AddSource(@namespace, builder.ToSourceText());
                }
            }
        }
    }
}
