# StaticDecoderCp932
The Static Decoder Method of CP932 which can be used from the Unity C# Job System.

これはC# Job System + Burst CompilerでマルチスレッドにShift JISでエンコーディングされたbyte*を読み出してushort*（char*）に読み替える為のライブラリです。