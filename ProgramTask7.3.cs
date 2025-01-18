using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите позицию белой ладьи: ");
        var whiteRookPosition = Console.ReadLine();

        Console.WriteLine("Введите позицию черного слона: ");
        var blackBishopPosition = Console.ReadLine();

        Console.WriteLine("Введите позицию хода белой ладьи: ");
        var move = Console.ReadLine();

        if (IsWhiteRookMoveCorrect(whiteRookPosition, move) && !IsBlackBishopCanStrike(blackBishopPosition, move))
        {
            Console.WriteLine("Ход белой ладьи возможен.");
        }
        else
        {
            Console.WriteLine("Ладья не может ходить сюда, так как находится под боем.");
        }

        Console.ReadKey();
    }

    static void DecodePosition(string position, out int column, out int row)
    {
        column = (int)position[0] - 0x60;
        row = int.Parse(position[1].ToString());
    }

    static bool IsWhiteRookMoveCorrect(string whiteRookPosition, string move)
    {
        int wrRow, wrColumn, mRow, mColumn;

        DecodePosition(whiteRookPosition, out wrColumn, out wrRow);
        DecodePosition(move, out mColumn, out mRow);

        return wrRow == mRow || wrColumn == mColumn;
    }

    static bool IsBlackBishopCanStrike(string blackBishopPosition, string position)
    {
        int bbRow, bbColumn, pRow, pColumn;

        DecodePosition(blackBishopPosition, out bbColumn, out bbRow);
        DecodePosition(position, out pColumn, out pRow);

        return Math.Abs(bbRow - pRow) == Math.Abs(bbColumn - pColumn);
    }
}
