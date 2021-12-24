using System.Text;

namespace Poemdown.Blaze.Shared;

public static class PoemdownConvert {

	public const int TabSize = 4;


	#region searching-your-eyes-for-a-hint-or-trace-of-it

	/////////////////////////////////////////////////////////////////////////////////////////CROWN//
	// >>> poemdown-formatted text
	// <<< HTML-formatted text that represents the poemdown input
	//----------------------------------------------------------------------------------------------
	public static string ToHtml(string poemdown) {
		int lineCharCount = 0;

		var html = new StringBuilder();
		html.Append("<span style='color:red;'>");

		foreach ( char c in poemdown ) {
			if ( IsHtmlWhitespace(c, ref lineCharCount, out string whiteHtml) ) {
				html.Append(whiteHtml);
				continue;
			}

			html.Append(c);
			lineCharCount++;
		}

		html.Append("</span>");
		return html.ToString();
	}

	//----------------------------------------------------------------------------------------------
	// >>> any single character
	// <-> the number of characters in the current line
	// <-- HTML-formatted text that represents the character input
	// <<< does the character input cause an HTML-formatted result?
	//----------------------------------------------------------------------------------------------
	public static bool IsHtmlWhitespace(char c, ref int lineCharCount, out string html) {
		switch ( c ) {
			case '\n':
				html = "<br/>";
				lineCharCount = 0;
				return true;

			case '\r':
				html = "";
				return true;

			case ' ':
				html = "&nbsp;";
				lineCharCount++;
				return true;

			case '\t':
				//test line:	1234	567	89	1	2
				int n = TabSize-(lineCharCount%TabSize);
				n = (n == 0 ? TabSize : n);

				string tabHtml = "";

				for ( int i = 0 ; i < n ; i++ ) {
					tabHtml += "&nbsp;";
					lineCharCount++;
				}

				html = tabHtml;
				return true;
		}

		html = "";
		return false;
	}

	#endregion


	#region golden-Light-upon-fertilizer

	////////////////////////////////////////////////////////////////////////////////////////////////
	// >>> poemdown-formatted text
	// <<< HTML-formatted text that represents the poemdown input
	//----------------------------------------------------------------------------------------------
	public static string ToHuespinHtml(string poemdown) {
		var html = new StringBuilder();
		int displayCharCount = 0;
		int lineCharCount = 0;
		const int hueSpeed = 3;

		foreach ( char c in poemdown ) {
			if ( IsHtmlWhitespace(c, ref lineCharCount, out string? whiteHtml) ) {
				html.Append(whiteHtml);
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

	#endregion

	//showing only					sorry delay
	//bits and pieces				too much to learn
	//til the Light betray you		hidden bits and pieces
	//and your empty elocution		they shall aid the execution

	// -<{ the holy recursion }>-

	//EVERYTHING BREAKS DOWN TWO
	//you find a way back to YOU
	//[crystallized pathways through]
	//net of Light guiding True
	//(no need left for the hourglass)

}
