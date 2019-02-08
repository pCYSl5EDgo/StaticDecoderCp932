# StaticDecoderCp932
The Static Decoder Method of CP932 which can be used from the Unity C# Job System.

これはC# Job System + Burst CompilerでマルチスレッドにShift JISでエンコーディングされたbyte*を読み出してushort*（char*）に読み替える為のライブラリです。

# 導入方法
Packages/manifest.jsonに
"jp.pcysl5edgo.burstdecodercp932" : "https://github.com/pCYSl5EDgo/StaticDecoderCp932.git",
と追加してください。

https://note.mu/fuqunaga/n/ne331cb5600fe
導入方法は上のリンクがかなりわかりやすいので参考にしてみてください。
