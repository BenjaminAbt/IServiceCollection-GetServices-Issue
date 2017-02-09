using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CqrsDemo.Commands;

namespace CqrsDemo.CommandLine.CommandsHandlers
{
    public class WriteInfoToCommandLineHandler : BaseCommandLineAsyncCommandHandler<WriteInfoCommand, TextWriter>
    {
        public WriteInfoToCommandLineHandler(TextWriter textWriter)
            : base(textWriter)
        {
            if (textWriter == null) throw new ArgumentNullException(nameof(textWriter));


        }

        public override async Task ExecuteAsync(WriteInfoCommand command)
        {

            await Writer.WriteLineAsync(command.Message);
        }
    }
}
