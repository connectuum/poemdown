using System.Text;

namespace Poemdown.Blaze.Shared;

public static class PoemdownConvert {


	#region aristocrat-breaks-down-----two //let us try something new

	public static string ToHtml(string poemdown) {
		int length = poemdown.Length;
		var html = new StringBuilder();

		for ( int i = 0 ; i < length ; i++ ) {
			int hue = 360*i/length;

			html.Append("<span style='color:hsl(");
			html.Append(hue);
			html.Append(", 62%, 62%);'>");
			html.Append(poemdown[i]);
			html.Append("</span>");
		}

		return html.ToString();
	}

	#endregion //something-that breaks to... sun?

	//something many-but-one

	//(five four three)

}
