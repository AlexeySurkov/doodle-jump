using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelInstruction
    { 
        private String _contentInstruction;
        public string ContentInstruction { get => _contentInstruction; }

        public ModelInstruction()
        {
            //Будет загружаться из файла ресурсов.
        }
    }
}
