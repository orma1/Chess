using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class AI
    {
        public static int evaluateBoard(Board board)
        {
            int whitevalue = 0;
            int blackvalue = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (board.locations[i, k].pc == PieceColor.White)
                    {
                        whitevalue += board.locations[i, k].value;
                    }
                    if (board.locations[i, k].pc == PieceColor.Black)
                    {
                        blackvalue += board.locations[i, k].value;
                    }
                }
            }
            return (whitevalue - blackvalue);
        }
        public static int minimax(TreeNode position, int depth, int alpha, int beta, bool maximizingPlayer)
        {
            if (depth == 0)
            {
                return evaluateBoard(position.board);
            }
            bool whiteking = false;
            bool blackking = false;
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (position.board.locations[i, k].pt == PieceType.King)
                    {
                        if (position.board.locations[i, k].pc == PieceColor.White) whiteking = true;
                        else blackking = true;
                    }
                }
            }
            if (!whiteking || !blackking) return evaluateBoard(position.board);

            if (maximizingPlayer)
            {
                int maxEval = int.MinValue;
                foreach (TreeNode child in position.childs)
                {
                    int eval = minimax(child, depth - 1, alpha, beta, false);
                    maxEval = Math.Max(maxEval, eval);
                    alpha = Math.Max(alpha, eval);
                    if (beta <= alpha) break;

                }
                return maxEval;


            }



            else
            {
                int minEval = int.MaxValue;
                foreach (TreeNode child in position.childs)
                {
                    int eval = minimax(child, depth - 1, alpha, beta, true);
                    minEval = Math.Min(minEval, eval);
                    beta = Math.Min(beta, eval);
                    if (beta <= alpha) break;
                }

                return minEval;
            }

        }
    }

}
