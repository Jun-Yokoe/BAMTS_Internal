using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BAMSS.Extensions
{
    public static class StringExtensions
    {
        private static string[] _ctrlStr = { "NUL", "SOH", "STX", "ETX", "EOT", "ENQ", "ACK", "BEL", "BS", "HT", "LF", "VT", "NP", "CR", "SO", "SI", "DLE", "DC1", "DC2", "DC3", "DC4", "NAK", "SYN", "ETB", "CAN", "EM", "SUB", "ESC", "FS", "GS", "RS", "US" };
        /// <summary>
        /// 文字列中の制御文字をログ表示用等に可視化する
        /// </summary>
        /// <param name="data">変換対象文字列</param>
        /// <param name="format">変換後フォーマット（無指定時は変換データそのまま）</param>
        /// <returns></returns>
        public static string VisualizationControlChar(this string data, string format = "{0}")
        {
            return Regex.Replace(data, @"\p{Cc}", str =>
            {
                int offset = str.Value[0];
                if (_ctrlStr.Length > offset)
                    return string.Format(format, _ctrlStr[offset]);
                else
                    return string.Format(format, string.Format("0x{0:X2}", _ctrlStr[offset]));
            });
        }

        /// <summary>
        /// このインスタンスから部分文字列を取得します。reverse: trueにて反転モードとなります、reverse: false時は通常のSubstring
        /// </summary>
        /// <param name="str">インスタンス</param>
        /// <param name="startIndex">true時、反転モードとなり、末尾からのインデックス番号となります。</param>
        /// <param name="length">true時、反転モードとなり、取得する末尾からの文字数となります。</param>
        /// <param name="reverse">true時、反転モードとなり、startIndexは文字列の末尾からのインデックス番号となります。</param>
        /// <returns></returns>
        public static string Substring(this string str, int startIndex, int length, bool reverse)
        {
            try
            {
                if (!reverse) return str.Substring(startIndex, length);
                return str.Substring(str.Length - length - startIndex, length);
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// このインスタンスから部分文字列を取得します。reverse: trueにて反転モードとなります、reverse: false時は通常のSubstring
        /// </summary>
        /// <param name="str">インスタンス</param>
        /// <param name="startIndex">true時、反転モードとなり、末尾からのインデックス番号となります。この位置から前部分全てを返します。</param>
        /// <param name="reverse">true時、反転モードとなり、startIndexは文字列の末尾からのインデックス番号となります。</param>
        /// <returns></returns>
        public static string Substring(this string str, int startIndex, bool reverse)
        {
            if (!reverse) return str.Substring(startIndex);
            return str.Substring(0, str.Length - startIndex);
        }
    }
}
