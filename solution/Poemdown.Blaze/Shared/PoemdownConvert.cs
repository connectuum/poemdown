using System.Text;

namespace Poemdown.Blaze.Shared;

public static class PoemdownConvert {


	#region aristocrat-breaks-down-----two //let us try something new

	public static string ToHtml(string poemdown) {
		var html = new StringBuilder();
		int hueSpeed = 3;
		int displayCharCount = 0;
		int lineCharCount = 0;
		const int tabSize = 4;

		foreach ( char c in poemdown ) {
			switch ( c ) {
				case '\n':
					html.Append("<br/>");
					lineCharCount = 0;
					continue;

				case '\r':
					continue;

				case ' ':
					html.Append("&nbsp;");
					lineCharCount++;
					continue;

				case '\t':
					//test line:	1234	567	89	1	2
					int spaceCount = tabSize-lineCharCount%tabSize;
					spaceCount = (spaceCount == 0 ? tabSize : spaceCount);

					for ( int i = 0 ; i < spaceCount ; i++ ) {
						html.Append("&nbsp;");
						lineCharCount++;
					}

					continue;
			}

			int hue = hueSpeed*displayCharCount;

			displayCharCount++;
			lineCharCount++;

			html.Append("<span style='color:hsl(");
			html.Append(hue);
			html.Append(", 62%, 62%);'>");
			html.Append(c);
			html.Append("</span>");
		}

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
