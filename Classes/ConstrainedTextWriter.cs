using System.Collections.Generic;
using System.Linq;

namespace BaboonComputer.Classes
{
    public class ConstrainedTextWriter(int constrainedX)
    {
        private string _text = "";

        public string GetText() => _text;

        public void SetText(string text, ref string forwardTo)
        {
            _text = text;

            var maxX = 0;
            var lines = text.Split('\n').ToList();

            lines.ForEach(line =>
                maxX = (line.Length > maxX ? line.Length : maxX)
            );

            if (maxX <= constrainedX)
            {
                forwardTo = text;
                return;
            }

            var output = new List<string> { };

            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];

                if (line.Length <= constrainedX)
                {
                    output.Add(line);
                    return;
                }

                var cutLine = line[..(constrainedX + 1)];
                var after = line[(constrainedX + 1) ..];

                output.Add(cutLine);
                lines.Insert(i + 1, after); // inserting it into the list so the next iteration will do the splitting for us
            }

            forwardTo = string.Join('\n', output);
        }
    }
}
