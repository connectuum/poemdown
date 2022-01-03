using System.Text;
using System.Text.RegularExpressions;

namespace Poemdown.Core;

public static class Convert {

	public const int TabSize = 4;


	#region searching-your-eyes-for-a-hint-or-trace-of-it

	/////////////////////////////////////////////////////////////////////////////////////////CROWN//
	// >>> poemdown-formatted text
	// <<< HTML-formatted text that represents the poemdown input
	//----------------------------------------------------------------------------------------------
	public static string ToOverlayHtml(in string poemdown) {
		string html = poemdown;
		html = Regex.Replace(html, @"\r", "");
		html = Regex.Replace(html, @"(\*)([^\*\n]+)(\*)", "<b><c>$1</c>$2<c>$3</c></b>");
		html = Regex.Replace(html, @"(_)([^_\n]+)(_)", "<em><c>$1</c>$2<c>$3</c></em>");
		html = Regex.Replace(html, @"(`)([^`\n]+|`)(`)", "<mono><c>$1</c>$2<c>$3</c></mono>");
		html = Regex.Replace(html, @"(^|\n)(---)([ \t]*)($|\n)","$1<line><c>$2</c></line>$3<hr/>");
		html = Regex.Replace(html, @"(^|\n)(#)(\s+[^$\n]+)", "$1<head1><c>$2</c>$3</head1>");
		html = Regex.Replace(html, @"(^|\n)(##)(\s+[^$\n]+)", "$1<head2><c>$2</c>$3</head2>");
		html = Regex.Replace(html, @"(^|\n)(###)(\s+[^$\n]+)", "$1<head3><c>$2</c>$3</head3>");

		var htmlBuild = new StringBuilder();
		int lineCharCount = 0;

		foreach ( char c in html ) {
			if ( IsHtmlWhitespace(c, ref lineCharCount, out string whiteHtml) ) {
				htmlBuild.Append(whiteHtml);
				continue;
			}

			htmlBuild.Append(c);
			lineCharCount++;
		}

		return htmlBuild.ToString();
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

			case '\v': //special case: repurpose 'vertical-tab' as an escaped 'space'
				html = " ";
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
