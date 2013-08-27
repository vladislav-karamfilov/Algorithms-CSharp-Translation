int[] LpcEncode(string msg) /* Извършва LPC кодиране на съобщението */
{ if (msg == "") return new int[0]; /* Празно входно съобщение */
  int[] code = new int[msg.Length];
  double exp = code[0] = msg[0];
  for (int i = 1; i < msg.Length; i++) {
    code[i] = (int)Math.Ceiling(exp - msg[i]);
    exp = (exp*i + msg[i]) / (i + 1);
  }
  return code;
}

string LpcDecode(int[] code) /*Извършва LPC декодиране*/
{ if (code.Length == 0) return "";
  double exp = code[0];
  var msg = new StringBuilder();
  msg.Append((char)code[0]);
  for (int i = 1; i < code.Length; i++) {
    msg.Append((char)Math.Ceiling(exp - code[i]));
    exp = (exp*i + msg[i]) / (i+1);
  }
  return msg.ToString();
}

void Main() {
  const string message = "LLLLLLALABALANICAAAABABABBABABABABAAABABALLLLAABB";

  Console.WriteLine("Входно съобщение: {0}", message);

  int[] code = LpcEncode(message);
  Console.WriteLine("Кодирано съобщение: {0}", string.Join(",", code));

  string decoded = LpcDecode(code);
  Console.WriteLine("Декодирано съобщение: {0}", decoded);
}

















