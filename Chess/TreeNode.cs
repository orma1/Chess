using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class TreeNode
    {
        public List<TreeNode> childs;
        public Board board;
        public TreeNode(Board board)
        {
            this.board = board;
            childs = new List<TreeNode>();
        }
        public void AddChild()
        {
            TreeNode child = new TreeNode(board);
            childs.Add(child);
        }
        public void BuildMovesTree()
        {
            //TreeNode movesTree = new TreeNode(board);
            BuildLevel(this, board, PieceColor.White);
            List<TreeNode> children = new List<TreeNode>();
            children = childs;
            foreach (TreeNode c in children)
            {
                BuildLevel(c, c.board, PieceColor.Black);
            }
            List<TreeNode> grandchildren = new List<TreeNode>();
            foreach (TreeNode c in children)
            {
                List<TreeNode> temp = new List<TreeNode>();
                temp = c.childs;
                foreach (TreeNode g in temp)
                {
                    grandchildren = g.childs;
                    BuildLevel(g, g.board, PieceColor.White);
                }
            }
        }
        public void BuildLevel(TreeNode root, Board board, PieceColor pc)
        {
            List<Spot> eat = new List<Spot>();
            List<Spot> move = new List<Spot>();
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (board.locations[i, k].pc == pc)
                    {
                        eat = board.locations[i, k].eatingLocations(board);
                        move = board.locations[i, k].movingLocations(board);
                        foreach (Spot s in eat)
                        {
                            Board temp = new Board(board);
                            temp.locations[i, k].eat(s, board);
                            root.childs.Add(new TreeNode(temp));
                        }
                        foreach (Spot s in move)
                        {
                            Board temp = new Board(board);
                            temp.locations[i, k].move(s, board);
                            root.childs.Add(new TreeNode(temp));
                        }
                    }
                }
            }
        }
    }
}
