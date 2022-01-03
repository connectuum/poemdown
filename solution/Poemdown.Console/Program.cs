using Poemdown.Blaze.Shared;

const string sampleText = @"
does _this_ actually *work*?

---

# test single
more things
e	v	e		n more

## test double
something else

### test triple

this is the `testing` code
";

string html = PoemdownConvert.ToOverlayHtml(sampleText);
html = html.Replace("<br/>", "<br/>\n");

Console.WriteLine($"RESULT\n{html}");
