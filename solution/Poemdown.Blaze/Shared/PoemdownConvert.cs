using System.Text;

namespace Poemdown.Blaze.Shared;

public static class PoemdownConvert {


	#region aristocrat-breaks-down-----two //let us try something new

	public static string ToHtml(string poemdown) {
		var html = new StringBuilder();
		int hueSpeed = 3;
		int displayCharCount = 0;

		foreach ( char c in poemdown ) {
			//Console.WriteLine($"TEST {(int)c} '{c}'"); //{(int)'\n'} {(int)'\r'}");

			switch ( c ) {
				case '\n':
					html.Append("<br/>");
					continue;
				case '\r':
					continue;
				case ' ':
					html.Append("&nbsp;");
					continue;
				case '\t':
					html.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
					continue;
			}

			int hue = hueSpeed*displayCharCount;
			displayCharCount++;

			html.Append("<span style='color:hsl(");
			html.Append(hue);
			html.Append(", 62%, 62%);'>");
			html.Append(c);
			html.Append("</span>");
		}

		Console.WriteLine($"HTML {html}");
		return html.ToString();
	}

	#endregion //something-that breaks to... sun? becomes.

	//something many-but-one
	//something all but none

	//(five four three)
	//to many of one
	//to every from none
	//the path has begun
	//to connectuum

}
