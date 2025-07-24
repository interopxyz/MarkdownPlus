using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sd = System.Drawing;
using Rg = Rhino.Geometry;

namespace MarkdownPlus
{
    public class Constants
    {

        #region naming

        public static string UniqueName
        {
            get { return ShortName + "_" + DateTime.UtcNow.ToString("yyyy-dd-M_HH-mm-ss"); }
        }

        public static string LongName
        {
            get { return ShortName + " v" + Major + "." + Minor; }
        }

        public static string ShortName
        {
            get { return "MarkdownPlus"; }
        }

        private static string Minor
        {
            get { return typeof(Constants).Assembly.GetName().Version.Minor.ToString(); }
        }
        private static string Major
        {
            get { return typeof(Constants).Assembly.GetName().Version.Major.ToString(); }
        }

        public static string SubSets
        {
            get { return "Sets"; }
        }

        public static string SubText
        {
            get { return "Text"; }
        }

        public static string SubMarkdown
        {
            get { return "Markdown"; }
        }

        #endregion

        #region inputs / outputs

        public static Descriptor Text
        {
            get { return new Descriptor("Text", "T", "Text to Modify", "Text to Modify", "Modified Text", "Modified Text"); }
        }

        public static Descriptor MarkdownText
        {
            get { return new Descriptor("Markdown Txt", "M", "Formatted Markdown Text", "Formatted Markdown Text", "Formatted Markdown Text", "Formatted Markdown Text"); }
        }

        public static Descriptor HtmlText
        {
            get { return new Descriptor("Html Txt", "H", "Formatted Html Text", "Formatted Html Text", "Formatted Html Text", "Formatted Html Text"); }
        }

        #endregion

        #region geometry

        #endregion

        #region color

        #endregion
    }

    public class Descriptor
    {
        private string name = string.Empty;
        private string nickname = string.Empty;
        private string input = string.Empty;
        private string inputs = string.Empty;
        private string output = string.Empty;
        private string outputs = string.Empty;

        public Descriptor(string name, string nickname, string input, string inputs, string output, string outputs)
        {
            this.name = name;
            this.nickname = nickname;
            this.input = input;
            this.inputs = inputs;
            this.output = output;
            this.outputs = outputs;
        }

        public virtual string Name
        {
            get { return name; }
        }

        public virtual string NickName
        {
            get { return nickname; }
        }

        public virtual string Input
        {
            get { return input; }
        }

        public virtual string Output
        {
            get { return output; }
        }

        public virtual string Inputs
        {
            get { return inputs; }
        }

        public virtual string Outputs
        {
            get { return outputs; }
        }
    }
}
