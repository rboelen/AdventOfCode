using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 4)]
    internal class Day4 : Day.NewLineSplitParsed<string>
    {
        public class Board
        {
            public int[][] Rows { get; set; }
            public bool Win { get; set; }
        }

        public override object ExecutePart1()
        {
            var numbers = GetNumbers();
            var boards = GetBoards();

            foreach (var n in numbers)
            {
                foreach (var board in boards)
                {
                    // update 
                    UpdateBoard(n, board);

                    // check
                    if (IsWinner(board))
                    {
                        // return answer
                        return n * SumUnmarked(board);
                    }
                }
            }

            return 0;
        }


        public override object ExecutePart2()
        {
            var numbers = GetNumbers();
            var boards = GetBoards();

            foreach (var n in numbers)
            {
                foreach (var board in boards)
                {
                    // update 
                    UpdateBoard(n, board);

                    // check
                    var isWinner = IsWinner(board);
                    if (boards.Count == 1 && isWinner)
                    {
                        // return answer
                        return n * SumUnmarked(board);
                    }
                }

                boards = boards.Where(x => x.Win == false).ToList();
            }

            return 0;
        }

        private List<Board> GetBoards()
        {
            var boards = new List<Board>();

            var lines = Input.Skip(1).Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(s => s.Split(new char[0], options: StringSplitOptions.RemoveEmptyEntries)
                .Select(n => Convert.ToInt32(n)).ToArray());

            var id = 0;
            var boardRows = lines.Skip(id * 5).Take(5);
            while (boardRows.Any())
            {
                boards.Add(new Board
                {
                    Rows = boardRows.ToArray()
                });
                id++;
                boardRows = lines.Skip(id * 5).Take(5);
            }

            return boards;
        }

        private IEnumerable<int> GetNumbers()
        {
            // input is firt line
            return Input[0].Split(",").Select(x => Convert.ToInt32(x));
        }

        private void UpdateBoard(int n, Board board)
        {
            for (int i = 0; i < board.Rows.Length; i++)
            {
                board.Rows[i] = board.Rows[i].Select(c => c == n ? -1 : c).ToArray();
            }
        }

        private bool IsWinner(Board board)
        {
            // check rows
            if(board.Rows.Any(r => r.All(c => c == -1)))
            {
                return board.Win = true;
            }
            // columns
            for (int i = 0; i < 5; i++)
            {
                if (board.Rows.All(r => r[i] == -1))
                {
                    return board.Win = true;
                }
            }
            return false;
        }

        private int SumUnmarked(Board board)
        {
            return board.Rows.Sum(r => r.Where(c => c != -1).Sum());
        }

    }
}
