namespace pcysl5edgo.BurstEncoding
{
    public unsafe static class Cp932Decoder
    {
        static ulong GetCharCount(byte* ptr, ulong length)
        {
            ulong charCount = 0;
            while (length > 0)
            {
                byte currentByte = *ptr++;
                if (currentByte <= 0x7f || (currentByte >= 0xa1 && currentByte <= 0xdf))
                {
                    ++charCount;
                    --length;
                    continue;
                }
                length -= 2;
                ++charCount;
            }
            return charCount;
        }
        // 安全性？　知るか！
        static void GetChars(byte* ptr, ulong length, ushort* str)
        {
            while (length > 0)
            {
                byte currentByte = *ptr++;
                --length;
                if (currentByte <= 0x7f)
                {
                    *str++ = (ushort)currentByte;
                    continue;
                }
                if (currentByte >= 0xa1 && currentByte <= 0xdf)
                {
                    *str++ = (ushort)(currentByte + 0xfec0);
                    continue;
                }
                --length;
                switch ((currentByte << 8) + (*ptr++))
                {
                    case 0x8140:
                        *str++ = '　';
                        break;
                    case 0x8141:
                        *str++ = '、';
                        break;
                    case 0x8142:
                        *str++ = '。';
                        break;
                    case 0x8143:
                        *str++ = '，';
                        break;
                    case 0x8144:
                        *str++ = '．';
                        break;
                    case 0x8145:
                        *str++ = '・';
                        break;
                    case 0x8146:
                        *str++ = '：';
                        break;
                    case 0x8147:
                        *str++ = '；';
                        break;
                    case 0x8148:
                        *str++ = '？';
                        break;
                    case 0x8149:
                        *str++ = '！';
                        break;
                    case 0x814A:
                        *str++ = '゛';
                        break;
                    case 0x814B:
                        *str++ = '゜';
                        break;
                    case 0x814C:
                        *str++ = '´';
                        break;
                    case 0x814D:
                        *str++ = '｀';
                        break;
                    case 0x814E:
                        *str++ = '¨';
                        break;
                    case 0x814F:
                        *str++ = '＾';
                        break;
                    case 0x8150:
                        *str++ = '￣';
                        break;
                    case 0x8151:
                        *str++ = '＿';
                        break;
                    case 0x8152:
                        *str++ = 'ヽ';
                        break;
                    case 0x8153:
                        *str++ = 'ヾ';
                        break;
                    case 0x8154:
                        *str++ = 'ゝ';
                        break;
                    case 0x8155:
                        *str++ = 'ゞ';
                        break;
                    case 0x8156:
                        *str++ = '〃';
                        break;
                    case 0x8157:
                        *str++ = '仝';
                        break;
                    case 0x8158:
                        *str++ = '々';
                        break;
                    case 0x8159:
                        *str++ = '〆';
                        break;
                    case 0x815A:
                        *str++ = '〇';
                        break;
                    case 0x815B:
                        *str++ = 'ー';
                        break;
                    case 0x815C:
                        *str++ = '―';
                        break;
                    case 0x815D:
                        *str++ = '‐';
                        break;
                    case 0x815E:
                        *str++ = '／';
                        break;
                    case 0x815F:
                        *str++ = '＼';
                        break;
                    case 0x8160:
                        *str++ = '～';
                        break;
                    case 0x8161:
                        *str++ = '∥';
                        break;
                    case 0x8162:
                        *str++ = '｜';
                        break;
                    case 0x8163:
                        *str++ = '…';
                        break;
                    case 0x8164:
                        *str++ = '‥';
                        break;
                    case 0x8165:
                        *str++ = '‘';
                        break;
                    case 0x8166:
                        *str++ = '’';
                        break;
                    case 0x8167:
                        *str++ = '“';
                        break;
                    case 0x8168:
                        *str++ = '”';
                        break;
                    case 0x8169:
                        *str++ = '（';
                        break;
                    case 0x816A:
                        *str++ = '）';
                        break;
                    case 0x816B:
                        *str++ = '〔';
                        break;
                    case 0x816C:
                        *str++ = '〕';
                        break;
                    case 0x816D:
                        *str++ = '［';
                        break;
                    case 0x816E:
                        *str++ = '］';
                        break;
                    case 0x816F:
                        *str++ = '｛';
                        break;
                    case 0x8170:
                        *str++ = '｝';
                        break;
                    case 0x8171:
                        *str++ = '〈';
                        break;
                    case 0x8172:
                        *str++ = '〉';
                        break;
                    case 0x8173:
                        *str++ = '《';
                        break;
                    case 0x8174:
                        *str++ = '》';
                        break;
                    case 0x8175:
                        *str++ = '「';
                        break;
                    case 0x8176:
                        *str++ = '」';
                        break;
                    case 0x8177:
                        *str++ = '『';
                        break;
                    case 0x8178:
                        *str++ = '』';
                        break;
                    case 0x8179:
                        *str++ = '【';
                        break;
                    case 0x817A:
                        *str++ = '】';
                        break;
                    case 0x817B:
                        *str++ = '＋';
                        break;
                    case 0x817C:
                        *str++ = '－';
                        break;
                    case 0x817D:
                        *str++ = '±';
                        break;
                    case 0x817E:
                        *str++ = '×';
                        break;
                    case 0x8180:
                        *str++ = '÷';
                        break;
                    case 0x8181:
                        *str++ = '＝';
                        break;
                    case 0x8182:
                        *str++ = '≠';
                        break;
                    case 0x8183:
                        *str++ = '＜';
                        break;
                    case 0x8184:
                        *str++ = '＞';
                        break;
                    case 0x8185:
                        *str++ = '≦';
                        break;
                    case 0x8186:
                        *str++ = '≧';
                        break;
                    case 0x8187:
                        *str++ = '∞';
                        break;
                    case 0x8188:
                        *str++ = '∴';
                        break;
                    case 0x8189:
                        *str++ = '♂';
                        break;
                    case 0x818A:
                        *str++ = '♀';
                        break;
                    case 0x818B:
                        *str++ = '°';
                        break;
                    case 0x818C:
                        *str++ = '′';
                        break;
                    case 0x818D:
                        *str++ = '″';
                        break;
                    case 0x818E:
                        *str++ = '℃';
                        break;
                    case 0x818F:
                        *str++ = '￥';
                        break;
                    case 0x8190:
                        *str++ = '＄';
                        break;
                    case 0x8191:
                        *str++ = '￠';
                        break;
                    case 0x8192:
                        *str++ = '￡';
                        break;
                    case 0x8193:
                        *str++ = '％';
                        break;
                    case 0x8194:
                        *str++ = '＃';
                        break;
                    case 0x8195:
                        *str++ = '＆';
                        break;
                    case 0x8196:
                        *str++ = '＊';
                        break;
                    case 0x8197:
                        *str++ = '＠';
                        break;
                    case 0x8198:
                        *str++ = '§';
                        break;
                    case 0x8199:
                        *str++ = '☆';
                        break;
                    case 0x819A:
                        *str++ = '★';
                        break;
                    case 0x819B:
                        *str++ = '○';
                        break;
                    case 0x819C:
                        *str++ = '●';
                        break;
                    case 0x819D:
                        *str++ = '◎';
                        break;
                    case 0x819E:
                        *str++ = '◇';
                        break;
                    case 0x819F:
                        *str++ = '◆';
                        break;
                    case 0x81A0:
                        *str++ = '□';
                        break;
                    case 0x81A1:
                        *str++ = '■';
                        break;
                    case 0x81A2:
                        *str++ = '△';
                        break;
                    case 0x81A3:
                        *str++ = '▲';
                        break;
                    case 0x81A4:
                        *str++ = '▽';
                        break;
                    case 0x81A5:
                        *str++ = '▼';
                        break;
                    case 0x81A6:
                        *str++ = '※';
                        break;
                    case 0x81A7:
                        *str++ = '〒';
                        break;
                    case 0x81A8:
                        *str++ = '→';
                        break;
                    case 0x81A9:
                        *str++ = '←';
                        break;
                    case 0x81AA:
                        *str++ = '↑';
                        break;
                    case 0x81AB:
                        *str++ = '↓';
                        break;
                    case 0x81AC:
                        *str++ = '〓';
                        break;
                    case 0x81B8:
                        *str++ = '∈';
                        break;
                    case 0x81B9:
                        *str++ = '∋';
                        break;
                    case 0x81BA:
                        *str++ = '⊆';
                        break;
                    case 0x81BB:
                        *str++ = '⊇';
                        break;
                    case 0x81BC:
                        *str++ = '⊂';
                        break;
                    case 0x81BD:
                        *str++ = '⊃';
                        break;
                    case 0x81BE:
                        *str++ = '∪';
                        break;
                    case 0x81BF:
                        *str++ = '∩';
                        break;
                    case 0x81C8:
                        *str++ = '∧';
                        break;
                    case 0x81C9:
                        *str++ = '∨';
                        break;
                    case 0x81CA:
                        *str++ = '￢';
                        break;
                    case 0x81CB:
                        *str++ = '⇒';
                        break;
                    case 0x81CC:
                        *str++ = '⇔';
                        break;
                    case 0x81CD:
                        *str++ = '∀';
                        break;
                    case 0x81CE:
                        *str++ = '∃';
                        break;
                    case 0x81DA:
                        *str++ = '∠';
                        break;
                    case 0x81DB:
                        *str++ = '⊥';
                        break;
                    case 0x81DC:
                        *str++ = '⌒';
                        break;
                    case 0x81DD:
                        *str++ = '∂';
                        break;
                    case 0x81DE:
                        *str++ = '∇';
                        break;
                    case 0x81DF:
                        *str++ = '≡';
                        break;
                    case 0x81E0:
                        *str++ = '≒';
                        break;
                    case 0x81E1:
                        *str++ = '≪';
                        break;
                    case 0x81E2:
                        *str++ = '≫';
                        break;
                    case 0x81E3:
                        *str++ = '√';
                        break;
                    case 0x81E4:
                        *str++ = '∽';
                        break;
                    case 0x81E5:
                        *str++ = '∝';
                        break;
                    case 0x81E6:
                        *str++ = '∵';
                        break;
                    case 0x81E7:
                        *str++ = '∫';
                        break;
                    case 0x81E8:
                        *str++ = '∬';
                        break;
                    case 0x81F0:
                        *str++ = 'Å';
                        break;
                    case 0x81F1:
                        *str++ = '‰';
                        break;
                    case 0x81F2:
                        *str++ = '♯';
                        break;
                    case 0x81F3:
                        *str++ = '♭';
                        break;
                    case 0x81F4:
                        *str++ = '♪';
                        break;
                    case 0x81F5:
                        *str++ = '†';
                        break;
                    case 0x81F6:
                        *str++ = '‡';
                        break;
                    case 0x81F7:
                        *str++ = '¶';
                        break;
                    case 0x81FC:
                        *str++ = '◯';
                        break;
                    case 0x824F:
                        *str++ = '０';
                        break;
                    case 0x8250:
                        *str++ = '１';
                        break;
                    case 0x8251:
                        *str++ = '２';
                        break;
                    case 0x8252:
                        *str++ = '３';
                        break;
                    case 0x8253:
                        *str++ = '４';
                        break;
                    case 0x8254:
                        *str++ = '５';
                        break;
                    case 0x8255:
                        *str++ = '６';
                        break;
                    case 0x8256:
                        *str++ = '７';
                        break;
                    case 0x8257:
                        *str++ = '８';
                        break;
                    case 0x8258:
                        *str++ = '９';
                        break;
                    case 0x8260:
                        *str++ = 'Ａ';
                        break;
                    case 0x8261:
                        *str++ = 'Ｂ';
                        break;
                    case 0x8262:
                        *str++ = 'Ｃ';
                        break;
                    case 0x8263:
                        *str++ = 'Ｄ';
                        break;
                    case 0x8264:
                        *str++ = 'Ｅ';
                        break;
                    case 0x8265:
                        *str++ = 'Ｆ';
                        break;
                    case 0x8266:
                        *str++ = 'Ｇ';
                        break;
                    case 0x8267:
                        *str++ = 'Ｈ';
                        break;
                    case 0x8268:
                        *str++ = 'Ｉ';
                        break;
                    case 0x8269:
                        *str++ = 'Ｊ';
                        break;
                    case 0x826A:
                        *str++ = 'Ｋ';
                        break;
                    case 0x826B:
                        *str++ = 'Ｌ';
                        break;
                    case 0x826C:
                        *str++ = 'Ｍ';
                        break;
                    case 0x826D:
                        *str++ = 'Ｎ';
                        break;
                    case 0x826E:
                        *str++ = 'Ｏ';
                        break;
                    case 0x826F:
                        *str++ = 'Ｐ';
                        break;
                    case 0x8270:
                        *str++ = 'Ｑ';
                        break;
                    case 0x8271:
                        *str++ = 'Ｒ';
                        break;
                    case 0x8272:
                        *str++ = 'Ｓ';
                        break;
                    case 0x8273:
                        *str++ = 'Ｔ';
                        break;
                    case 0x8274:
                        *str++ = 'Ｕ';
                        break;
                    case 0x8275:
                        *str++ = 'Ｖ';
                        break;
                    case 0x8276:
                        *str++ = 'Ｗ';
                        break;
                    case 0x8277:
                        *str++ = 'Ｘ';
                        break;
                    case 0x8278:
                        *str++ = 'Ｙ';
                        break;
                    case 0x8279:
                        *str++ = 'Ｚ';
                        break;
                    case 0x8281:
                        *str++ = 'ａ';
                        break;
                    case 0x8282:
                        *str++ = 'ｂ';
                        break;
                    case 0x8283:
                        *str++ = 'ｃ';
                        break;
                    case 0x8284:
                        *str++ = 'ｄ';
                        break;
                    case 0x8285:
                        *str++ = 'ｅ';
                        break;
                    case 0x8286:
                        *str++ = 'ｆ';
                        break;
                    case 0x8287:
                        *str++ = 'ｇ';
                        break;
                    case 0x8288:
                        *str++ = 'ｈ';
                        break;
                    case 0x8289:
                        *str++ = 'ｉ';
                        break;
                    case 0x828A:
                        *str++ = 'ｊ';
                        break;
                    case 0x828B:
                        *str++ = 'ｋ';
                        break;
                    case 0x828C:
                        *str++ = 'ｌ';
                        break;
                    case 0x828D:
                        *str++ = 'ｍ';
                        break;
                    case 0x828E:
                        *str++ = 'ｎ';
                        break;
                    case 0x828F:
                        *str++ = 'ｏ';
                        break;
                    case 0x8290:
                        *str++ = 'ｐ';
                        break;
                    case 0x8291:
                        *str++ = 'ｑ';
                        break;
                    case 0x8292:
                        *str++ = 'ｒ';
                        break;
                    case 0x8293:
                        *str++ = 'ｓ';
                        break;
                    case 0x8294:
                        *str++ = 'ｔ';
                        break;
                    case 0x8295:
                        *str++ = 'ｕ';
                        break;
                    case 0x8296:
                        *str++ = 'ｖ';
                        break;
                    case 0x8297:
                        *str++ = 'ｗ';
                        break;
                    case 0x8298:
                        *str++ = 'ｘ';
                        break;
                    case 0x8299:
                        *str++ = 'ｙ';
                        break;
                    case 0x829A:
                        *str++ = 'ｚ';
                        break;
                    case 0x829F:
                        *str++ = 'ぁ';
                        break;
                    case 0x82A0:
                        *str++ = 'あ';
                        break;
                    case 0x82A1:
                        *str++ = 'ぃ';
                        break;
                    case 0x82A2:
                        *str++ = 'い';
                        break;
                    case 0x82A3:
                        *str++ = 'ぅ';
                        break;
                    case 0x82A4:
                        *str++ = 'う';
                        break;
                    case 0x82A5:
                        *str++ = 'ぇ';
                        break;
                    case 0x82A6:
                        *str++ = 'え';
                        break;
                    case 0x82A7:
                        *str++ = 'ぉ';
                        break;
                    case 0x82A8:
                        *str++ = 'お';
                        break;
                    case 0x82A9:
                        *str++ = 'か';
                        break;
                    case 0x82AA:
                        *str++ = 'が';
                        break;
                    case 0x82AB:
                        *str++ = 'き';
                        break;
                    case 0x82AC:
                        *str++ = 'ぎ';
                        break;
                    case 0x82AD:
                        *str++ = 'く';
                        break;
                    case 0x82AE:
                        *str++ = 'ぐ';
                        break;
                    case 0x82AF:
                        *str++ = 'け';
                        break;
                    case 0x82B0:
                        *str++ = 'げ';
                        break;
                    case 0x82B1:
                        *str++ = 'こ';
                        break;
                    case 0x82B2:
                        *str++ = 'ご';
                        break;
                    case 0x82B3:
                        *str++ = 'さ';
                        break;
                    case 0x82B4:
                        *str++ = 'ざ';
                        break;
                    case 0x82B5:
                        *str++ = 'し';
                        break;
                    case 0x82B6:
                        *str++ = 'じ';
                        break;
                    case 0x82B7:
                        *str++ = 'す';
                        break;
                    case 0x82B8:
                        *str++ = 'ず';
                        break;
                    case 0x82B9:
                        *str++ = 'せ';
                        break;
                    case 0x82BA:
                        *str++ = 'ぜ';
                        break;
                    case 0x82BB:
                        *str++ = 'そ';
                        break;
                    case 0x82BC:
                        *str++ = 'ぞ';
                        break;
                    case 0x82BD:
                        *str++ = 'た';
                        break;
                    case 0x82BE:
                        *str++ = 'だ';
                        break;
                    case 0x82BF:
                        *str++ = 'ち';
                        break;
                    case 0x82C0:
                        *str++ = 'ぢ';
                        break;
                    case 0x82C1:
                        *str++ = 'っ';
                        break;
                    case 0x82C2:
                        *str++ = 'つ';
                        break;
                    case 0x82C3:
                        *str++ = 'づ';
                        break;
                    case 0x82C4:
                        *str++ = 'て';
                        break;
                    case 0x82C5:
                        *str++ = 'で';
                        break;
                    case 0x82C6:
                        *str++ = 'と';
                        break;
                    case 0x82C7:
                        *str++ = 'ど';
                        break;
                    case 0x82C8:
                        *str++ = 'な';
                        break;
                    case 0x82C9:
                        *str++ = 'に';
                        break;
                    case 0x82CA:
                        *str++ = 'ぬ';
                        break;
                    case 0x82CB:
                        *str++ = 'ね';
                        break;
                    case 0x82CC:
                        *str++ = 'の';
                        break;
                    case 0x82CD:
                        *str++ = 'は';
                        break;
                    case 0x82CE:
                        *str++ = 'ば';
                        break;
                    case 0x82CF:
                        *str++ = 'ぱ';
                        break;
                    case 0x82D0:
                        *str++ = 'ひ';
                        break;
                    case 0x82D1:
                        *str++ = 'び';
                        break;
                    case 0x82D2:
                        *str++ = 'ぴ';
                        break;
                    case 0x82D3:
                        *str++ = 'ふ';
                        break;
                    case 0x82D4:
                        *str++ = 'ぶ';
                        break;
                    case 0x82D5:
                        *str++ = 'ぷ';
                        break;
                    case 0x82D6:
                        *str++ = 'へ';
                        break;
                    case 0x82D7:
                        *str++ = 'べ';
                        break;
                    case 0x82D8:
                        *str++ = 'ぺ';
                        break;
                    case 0x82D9:
                        *str++ = 'ほ';
                        break;
                    case 0x82DA:
                        *str++ = 'ぼ';
                        break;
                    case 0x82DB:
                        *str++ = 'ぽ';
                        break;
                    case 0x82DC:
                        *str++ = 'ま';
                        break;
                    case 0x82DD:
                        *str++ = 'み';
                        break;
                    case 0x82DE:
                        *str++ = 'む';
                        break;
                    case 0x82DF:
                        *str++ = 'め';
                        break;
                    case 0x82E0:
                        *str++ = 'も';
                        break;
                    case 0x82E1:
                        *str++ = 'ゃ';
                        break;
                    case 0x82E2:
                        *str++ = 'や';
                        break;
                    case 0x82E3:
                        *str++ = 'ゅ';
                        break;
                    case 0x82E4:
                        *str++ = 'ゆ';
                        break;
                    case 0x82E5:
                        *str++ = 'ょ';
                        break;
                    case 0x82E6:
                        *str++ = 'よ';
                        break;
                    case 0x82E7:
                        *str++ = 'ら';
                        break;
                    case 0x82E8:
                        *str++ = 'り';
                        break;
                    case 0x82E9:
                        *str++ = 'る';
                        break;
                    case 0x82EA:
                        *str++ = 'れ';
                        break;
                    case 0x82EB:
                        *str++ = 'ろ';
                        break;
                    case 0x82EC:
                        *str++ = 'ゎ';
                        break;
                    case 0x82ED:
                        *str++ = 'わ';
                        break;
                    case 0x82EE:
                        *str++ = 'ゐ';
                        break;
                    case 0x82EF:
                        *str++ = 'ゑ';
                        break;
                    case 0x82F0:
                        *str++ = 'を';
                        break;
                    case 0x82F1:
                        *str++ = 'ん';
                        break;
                    case 0x8340:
                        *str++ = 'ァ';
                        break;
                    case 0x8341:
                        *str++ = 'ア';
                        break;
                    case 0x8342:
                        *str++ = 'ィ';
                        break;
                    case 0x8343:
                        *str++ = 'イ';
                        break;
                    case 0x8344:
                        *str++ = 'ゥ';
                        break;
                    case 0x8345:
                        *str++ = 'ウ';
                        break;
                    case 0x8346:
                        *str++ = 'ェ';
                        break;
                    case 0x8347:
                        *str++ = 'エ';
                        break;
                    case 0x8348:
                        *str++ = 'ォ';
                        break;
                    case 0x8349:
                        *str++ = 'オ';
                        break;
                    case 0x834A:
                        *str++ = 'カ';
                        break;
                    case 0x834B:
                        *str++ = 'ガ';
                        break;
                    case 0x834C:
                        *str++ = 'キ';
                        break;
                    case 0x834D:
                        *str++ = 'ギ';
                        break;
                    case 0x834E:
                        *str++ = 'ク';
                        break;
                    case 0x834F:
                        *str++ = 'グ';
                        break;
                    case 0x8350:
                        *str++ = 'ケ';
                        break;
                    case 0x8351:
                        *str++ = 'ゲ';
                        break;
                    case 0x8352:
                        *str++ = 'コ';
                        break;
                    case 0x8353:
                        *str++ = 'ゴ';
                        break;
                    case 0x8354:
                        *str++ = 'サ';
                        break;
                    case 0x8355:
                        *str++ = 'ザ';
                        break;
                    case 0x8356:
                        *str++ = 'シ';
                        break;
                    case 0x8357:
                        *str++ = 'ジ';
                        break;
                    case 0x8358:
                        *str++ = 'ス';
                        break;
                    case 0x8359:
                        *str++ = 'ズ';
                        break;
                    case 0x835A:
                        *str++ = 'セ';
                        break;
                    case 0x835B:
                        *str++ = 'ゼ';
                        break;
                    case 0x835C:
                        *str++ = 'ソ';
                        break;
                    case 0x835D:
                        *str++ = 'ゾ';
                        break;
                    case 0x835E:
                        *str++ = 'タ';
                        break;
                    case 0x835F:
                        *str++ = 'ダ';
                        break;
                    case 0x8360:
                        *str++ = 'チ';
                        break;
                    case 0x8361:
                        *str++ = 'ヂ';
                        break;
                    case 0x8362:
                        *str++ = 'ッ';
                        break;
                    case 0x8363:
                        *str++ = 'ツ';
                        break;
                    case 0x8364:
                        *str++ = 'ヅ';
                        break;
                    case 0x8365:
                        *str++ = 'テ';
                        break;
                    case 0x8366:
                        *str++ = 'デ';
                        break;
                    case 0x8367:
                        *str++ = 'ト';
                        break;
                    case 0x8368:
                        *str++ = 'ド';
                        break;
                    case 0x8369:
                        *str++ = 'ナ';
                        break;
                    case 0x836A:
                        *str++ = 'ニ';
                        break;
                    case 0x836B:
                        *str++ = 'ヌ';
                        break;
                    case 0x836C:
                        *str++ = 'ネ';
                        break;
                    case 0x836D:
                        *str++ = 'ノ';
                        break;
                    case 0x836E:
                        *str++ = 'ハ';
                        break;
                    case 0x836F:
                        *str++ = 'バ';
                        break;
                    case 0x8370:
                        *str++ = 'パ';
                        break;
                    case 0x8371:
                        *str++ = 'ヒ';
                        break;
                    case 0x8372:
                        *str++ = 'ビ';
                        break;
                    case 0x8373:
                        *str++ = 'ピ';
                        break;
                    case 0x8374:
                        *str++ = 'フ';
                        break;
                    case 0x8375:
                        *str++ = 'ブ';
                        break;
                    case 0x8376:
                        *str++ = 'プ';
                        break;
                    case 0x8377:
                        *str++ = 'ヘ';
                        break;
                    case 0x8378:
                        *str++ = 'ベ';
                        break;
                    case 0x8379:
                        *str++ = 'ペ';
                        break;
                    case 0x837A:
                        *str++ = 'ホ';
                        break;
                    case 0x837B:
                        *str++ = 'ボ';
                        break;
                    case 0x837C:
                        *str++ = 'ポ';
                        break;
                    case 0x837D:
                        *str++ = 'マ';
                        break;
                    case 0x837E:
                        *str++ = 'ミ';
                        break;
                    case 0x8380:
                        *str++ = 'ム';
                        break;
                    case 0x8381:
                        *str++ = 'メ';
                        break;
                    case 0x8382:
                        *str++ = 'モ';
                        break;
                    case 0x8383:
                        *str++ = 'ャ';
                        break;
                    case 0x8384:
                        *str++ = 'ヤ';
                        break;
                    case 0x8385:
                        *str++ = 'ュ';
                        break;
                    case 0x8386:
                        *str++ = 'ユ';
                        break;
                    case 0x8387:
                        *str++ = 'ョ';
                        break;
                    case 0x8388:
                        *str++ = 'ヨ';
                        break;
                    case 0x8389:
                        *str++ = 'ラ';
                        break;
                    case 0x838A:
                        *str++ = 'リ';
                        break;
                    case 0x838B:
                        *str++ = 'ル';
                        break;
                    case 0x838C:
                        *str++ = 'レ';
                        break;
                    case 0x838D:
                        *str++ = 'ロ';
                        break;
                    case 0x838E:
                        *str++ = 'ヮ';
                        break;
                    case 0x838F:
                        *str++ = 'ワ';
                        break;
                    case 0x8390:
                        *str++ = 'ヰ';
                        break;
                    case 0x8391:
                        *str++ = 'ヱ';
                        break;
                    case 0x8392:
                        *str++ = 'ヲ';
                        break;
                    case 0x8393:
                        *str++ = 'ン';
                        break;
                    case 0x8394:
                        *str++ = 'ヴ';
                        break;
                    case 0x8395:
                        *str++ = 'ヵ';
                        break;
                    case 0x8396:
                        *str++ = 'ヶ';
                        break;
                    case 0x839F:
                        *str++ = 'Α';
                        break;
                    case 0x83A0:
                        *str++ = 'Β';
                        break;
                    case 0x83A1:
                        *str++ = 'Γ';
                        break;
                    case 0x83A2:
                        *str++ = 'Δ';
                        break;
                    case 0x83A3:
                        *str++ = 'Ε';
                        break;
                    case 0x83A4:
                        *str++ = 'Ζ';
                        break;
                    case 0x83A5:
                        *str++ = 'Η';
                        break;
                    case 0x83A6:
                        *str++ = 'Θ';
                        break;
                    case 0x83A7:
                        *str++ = 'Ι';
                        break;
                    case 0x83A8:
                        *str++ = 'Κ';
                        break;
                    case 0x83A9:
                        *str++ = 'Λ';
                        break;
                    case 0x83AA:
                        *str++ = 'Μ';
                        break;
                    case 0x83AB:
                        *str++ = 'Ν';
                        break;
                    case 0x83AC:
                        *str++ = 'Ξ';
                        break;
                    case 0x83AD:
                        *str++ = 'Ο';
                        break;
                    case 0x83AE:
                        *str++ = 'Π';
                        break;
                    case 0x83AF:
                        *str++ = 'Ρ';
                        break;
                    case 0x83B0:
                        *str++ = 'Σ';
                        break;
                    case 0x83B1:
                        *str++ = 'Τ';
                        break;
                    case 0x83B2:
                        *str++ = 'Υ';
                        break;
                    case 0x83B3:
                        *str++ = 'Φ';
                        break;
                    case 0x83B4:
                        *str++ = 'Χ';
                        break;
                    case 0x83B5:
                        *str++ = 'Ψ';
                        break;
                    case 0x83B6:
                        *str++ = 'Ω';
                        break;
                    case 0x83BF:
                        *str++ = 'α';
                        break;
                    case 0x83C0:
                        *str++ = 'β';
                        break;
                    case 0x83C1:
                        *str++ = 'γ';
                        break;
                    case 0x83C2:
                        *str++ = 'δ';
                        break;
                    case 0x83C3:
                        *str++ = 'ε';
                        break;
                    case 0x83C4:
                        *str++ = 'ζ';
                        break;
                    case 0x83C5:
                        *str++ = 'η';
                        break;
                    case 0x83C6:
                        *str++ = 'θ';
                        break;
                    case 0x83C7:
                        *str++ = 'ι';
                        break;
                    case 0x83C8:
                        *str++ = 'κ';
                        break;
                    case 0x83C9:
                        *str++ = 'λ';
                        break;
                    case 0x83CA:
                        *str++ = 'μ';
                        break;
                    case 0x83CB:
                        *str++ = 'ν';
                        break;
                    case 0x83CC:
                        *str++ = 'ξ';
                        break;
                    case 0x83CD:
                        *str++ = 'ο';
                        break;
                    case 0x83CE:
                        *str++ = 'π';
                        break;
                    case 0x83CF:
                        *str++ = 'ρ';
                        break;
                    case 0x83D0:
                        *str++ = 'σ';
                        break;
                    case 0x83D1:
                        *str++ = 'τ';
                        break;
                    case 0x83D2:
                        *str++ = 'υ';
                        break;
                    case 0x83D3:
                        *str++ = 'φ';
                        break;
                    case 0x83D4:
                        *str++ = 'χ';
                        break;
                    case 0x83D5:
                        *str++ = 'ψ';
                        break;
                    case 0x83D6:
                        *str++ = 'ω';
                        break;
                    case 0x8440:
                        *str++ = 'А';
                        break;
                    case 0x8441:
                        *str++ = 'Б';
                        break;
                    case 0x8442:
                        *str++ = 'В';
                        break;
                    case 0x8443:
                        *str++ = 'Г';
                        break;
                    case 0x8444:
                        *str++ = 'Д';
                        break;
                    case 0x8445:
                        *str++ = 'Е';
                        break;
                    case 0x8446:
                        *str++ = 'Ё';
                        break;
                    case 0x8447:
                        *str++ = 'Ж';
                        break;
                    case 0x8448:
                        *str++ = 'З';
                        break;
                    case 0x8449:
                        *str++ = 'И';
                        break;
                    case 0x844A:
                        *str++ = 'Й';
                        break;
                    case 0x844B:
                        *str++ = 'К';
                        break;
                    case 0x844C:
                        *str++ = 'Л';
                        break;
                    case 0x844D:
                        *str++ = 'М';
                        break;
                    case 0x844E:
                        *str++ = 'Н';
                        break;
                    case 0x844F:
                        *str++ = 'О';
                        break;
                    case 0x8450:
                        *str++ = 'П';
                        break;
                    case 0x8451:
                        *str++ = 'Р';
                        break;
                    case 0x8452:
                        *str++ = 'С';
                        break;
                    case 0x8453:
                        *str++ = 'Т';
                        break;
                    case 0x8454:
                        *str++ = 'У';
                        break;
                    case 0x8455:
                        *str++ = 'Ф';
                        break;
                    case 0x8456:
                        *str++ = 'Х';
                        break;
                    case 0x8457:
                        *str++ = 'Ц';
                        break;
                    case 0x8458:
                        *str++ = 'Ч';
                        break;
                    case 0x8459:
                        *str++ = 'Ш';
                        break;
                    case 0x845A:
                        *str++ = 'Щ';
                        break;
                    case 0x845B:
                        *str++ = 'Ъ';
                        break;
                    case 0x845C:
                        *str++ = 'Ы';
                        break;
                    case 0x845D:
                        *str++ = 'Ь';
                        break;
                    case 0x845E:
                        *str++ = 'Э';
                        break;
                    case 0x845F:
                        *str++ = 'Ю';
                        break;
                    case 0x8460:
                        *str++ = 'Я';
                        break;
                    case 0x8470:
                        *str++ = 'а';
                        break;
                    case 0x8471:
                        *str++ = 'б';
                        break;
                    case 0x8472:
                        *str++ = 'в';
                        break;
                    case 0x8473:
                        *str++ = 'г';
                        break;
                    case 0x8474:
                        *str++ = 'д';
                        break;
                    case 0x8475:
                        *str++ = 'е';
                        break;
                    case 0x8476:
                        *str++ = 'ё';
                        break;
                    case 0x8477:
                        *str++ = 'ж';
                        break;
                    case 0x8478:
                        *str++ = 'з';
                        break;
                    case 0x8479:
                        *str++ = 'и';
                        break;
                    case 0x847A:
                        *str++ = 'й';
                        break;
                    case 0x847B:
                        *str++ = 'к';
                        break;
                    case 0x847C:
                        *str++ = 'л';
                        break;
                    case 0x847D:
                        *str++ = 'м';
                        break;
                    case 0x847E:
                        *str++ = 'н';
                        break;
                    case 0x8480:
                        *str++ = 'о';
                        break;
                    case 0x8481:
                        *str++ = 'п';
                        break;
                    case 0x8482:
                        *str++ = 'р';
                        break;
                    case 0x8483:
                        *str++ = 'с';
                        break;
                    case 0x8484:
                        *str++ = 'т';
                        break;
                    case 0x8485:
                        *str++ = 'у';
                        break;
                    case 0x8486:
                        *str++ = 'ф';
                        break;
                    case 0x8487:
                        *str++ = 'х';
                        break;
                    case 0x8488:
                        *str++ = 'ц';
                        break;
                    case 0x8489:
                        *str++ = 'ч';
                        break;
                    case 0x848A:
                        *str++ = 'ш';
                        break;
                    case 0x848B:
                        *str++ = 'щ';
                        break;
                    case 0x848C:
                        *str++ = 'ъ';
                        break;
                    case 0x848D:
                        *str++ = 'ы';
                        break;
                    case 0x848E:
                        *str++ = 'ь';
                        break;
                    case 0x848F:
                        *str++ = 'э';
                        break;
                    case 0x8490:
                        *str++ = 'ю';
                        break;
                    case 0x8491:
                        *str++ = 'я';
                        break;
                    case 0x849F:
                        *str++ = '─';
                        break;
                    case 0x84A0:
                        *str++ = '│';
                        break;
                    case 0x84A1:
                        *str++ = '┌';
                        break;
                    case 0x84A2:
                        *str++ = '┐';
                        break;
                    case 0x84A3:
                        *str++ = '┘';
                        break;
                    case 0x84A4:
                        *str++ = '└';
                        break;
                    case 0x84A5:
                        *str++ = '├';
                        break;
                    case 0x84A6:
                        *str++ = '┬';
                        break;
                    case 0x84A7:
                        *str++ = '┤';
                        break;
                    case 0x84A8:
                        *str++ = '┴';
                        break;
                    case 0x84A9:
                        *str++ = '┼';
                        break;
                    case 0x84AA:
                        *str++ = '━';
                        break;
                    case 0x84AB:
                        *str++ = '┃';
                        break;
                    case 0x84AC:
                        *str++ = '┏';
                        break;
                    case 0x84AD:
                        *str++ = '┓';
                        break;
                    case 0x84AE:
                        *str++ = '┛';
                        break;
                    case 0x84AF:
                        *str++ = '┗';
                        break;
                    case 0x84B0:
                        *str++ = '┣';
                        break;
                    case 0x84B1:
                        *str++ = '┳';
                        break;
                    case 0x84B2:
                        *str++ = '┫';
                        break;
                    case 0x84B3:
                        *str++ = '┻';
                        break;
                    case 0x84B4:
                        *str++ = '╋';
                        break;
                    case 0x84B5:
                        *str++ = '┠';
                        break;
                    case 0x84B6:
                        *str++ = '┯';
                        break;
                    case 0x84B7:
                        *str++ = '┨';
                        break;
                    case 0x84B8:
                        *str++ = '┷';
                        break;
                    case 0x84B9:
                        *str++ = '┿';
                        break;
                    case 0x84BA:
                        *str++ = '┝';
                        break;
                    case 0x84BB:
                        *str++ = '┰';
                        break;
                    case 0x84BC:
                        *str++ = '┥';
                        break;
                    case 0x84BD:
                        *str++ = '┸';
                        break;
                    case 0x84BE:
                        *str++ = '╂';
                        break;
                    case 0x8740:
                        *str++ = '①';
                        break;
                    case 0x8741:
                        *str++ = '②';
                        break;
                    case 0x8742:
                        *str++ = '③';
                        break;
                    case 0x8743:
                        *str++ = '④';
                        break;
                    case 0x8744:
                        *str++ = '⑤';
                        break;
                    case 0x8745:
                        *str++ = '⑥';
                        break;
                    case 0x8746:
                        *str++ = '⑦';
                        break;
                    case 0x8747:
                        *str++ = '⑧';
                        break;
                    case 0x8748:
                        *str++ = '⑨';
                        break;
                    case 0x8749:
                        *str++ = '⑩';
                        break;
                    case 0x874A:
                        *str++ = '⑪';
                        break;
                    case 0x874B:
                        *str++ = '⑫';
                        break;
                    case 0x874C:
                        *str++ = '⑬';
                        break;
                    case 0x874D:
                        *str++ = '⑭';
                        break;
                    case 0x874E:
                        *str++ = '⑮';
                        break;
                    case 0x874F:
                        *str++ = '⑯';
                        break;
                    case 0x8750:
                        *str++ = '⑰';
                        break;
                    case 0x8751:
                        *str++ = '⑱';
                        break;
                    case 0x8752:
                        *str++ = '⑲';
                        break;
                    case 0x8753:
                        *str++ = '⑳';
                        break;
                    case 0x8754:
                        *str++ = 'Ⅰ';
                        break;
                    case 0x8755:
                        *str++ = 'Ⅱ';
                        break;
                    case 0x8756:
                        *str++ = 'Ⅲ';
                        break;
                    case 0x8757:
                        *str++ = 'Ⅳ';
                        break;
                    case 0x8758:
                        *str++ = 'Ⅴ';
                        break;
                    case 0x8759:
                        *str++ = 'Ⅵ';
                        break;
                    case 0x875A:
                        *str++ = 'Ⅶ';
                        break;
                    case 0x875B:
                        *str++ = 'Ⅷ';
                        break;
                    case 0x875C:
                        *str++ = 'Ⅸ';
                        break;
                    case 0x875D:
                        *str++ = 'Ⅹ';
                        break;
                    case 0x875F:
                        *str++ = '㍉';
                        break;
                    case 0x8760:
                        *str++ = '㌔';
                        break;
                    case 0x8761:
                        *str++ = '㌢';
                        break;
                    case 0x8762:
                        *str++ = '㍍';
                        break;
                    case 0x8763:
                        *str++ = '㌘';
                        break;
                    case 0x8764:
                        *str++ = '㌧';
                        break;
                    case 0x8765:
                        *str++ = '㌃';
                        break;
                    case 0x8766:
                        *str++ = '㌶';
                        break;
                    case 0x8767:
                        *str++ = '㍑';
                        break;
                    case 0x8768:
                        *str++ = '㍗';
                        break;
                    case 0x8769:
                        *str++ = '㌍';
                        break;
                    case 0x876A:
                        *str++ = '㌦';
                        break;
                    case 0x876B:
                        *str++ = '㌣';
                        break;
                    case 0x876C:
                        *str++ = '㌫';
                        break;
                    case 0x876D:
                        *str++ = '㍊';
                        break;
                    case 0x876E:
                        *str++ = '㌻';
                        break;
                    case 0x876F:
                        *str++ = '㎜';
                        break;
                    case 0x8770:
                        *str++ = '㎝';
                        break;
                    case 0x8771:
                        *str++ = '㎞';
                        break;
                    case 0x8772:
                        *str++ = '㎎';
                        break;
                    case 0x8773:
                        *str++ = '㎏';
                        break;
                    case 0x8774:
                        *str++ = '㏄';
                        break;
                    case 0x8775:
                        *str++ = '㎡';
                        break;
                    case 0x877E:
                        *str++ = '㍻';
                        break;
                    case 0x8780:
                        *str++ = '〝';
                        break;
                    case 0x8781:
                        *str++ = '〟';
                        break;
                    case 0x8782:
                        *str++ = '№';
                        break;
                    case 0x8783:
                        *str++ = '㏍';
                        break;
                    case 0x8784:
                        *str++ = '℡';
                        break;
                    case 0x8785:
                        *str++ = '㊤';
                        break;
                    case 0x8786:
                        *str++ = '㊥';
                        break;
                    case 0x8787:
                        *str++ = '㊦';
                        break;
                    case 0x8788:
                        *str++ = '㊧';
                        break;
                    case 0x8789:
                        *str++ = '㊨';
                        break;
                    case 0x878A:
                        *str++ = '㈱';
                        break;
                    case 0x878B:
                        *str++ = '㈲';
                        break;
                    case 0x878C:
                        *str++ = '㈹';
                        break;
                    case 0x878D:
                        *str++ = '㍾';
                        break;
                    case 0x878E:
                        *str++ = '㍽';
                        break;
                    case 0x878F:
                        *str++ = '㍼';
                        break;
                    case 0x8790:
                        *str++ = '≒';
                        break;
                    case 0x8791:
                        *str++ = '≡';
                        break;
                    case 0x8792:
                        *str++ = '∫';
                        break;
                    case 0x8793:
                        *str++ = '∮';
                        break;
                    case 0x8794:
                        *str++ = '∑';
                        break;
                    case 0x8795:
                        *str++ = '√';
                        break;
                    case 0x8796:
                        *str++ = '⊥';
                        break;
                    case 0x8797:
                        *str++ = '∠';
                        break;
                    case 0x8798:
                        *str++ = '∟';
                        break;
                    case 0x8799:
                        *str++ = '⊿';
                        break;
                    case 0x879A:
                        *str++ = '∵';
                        break;
                    case 0x879B:
                        *str++ = '∩';
                        break;
                    case 0x879C:
                        *str++ = '∪';
                        break;
                    case 0x889F:
                        *str++ = '亜';
                        break;
                    case 0x88A0:
                        *str++ = '唖';
                        break;
                    case 0x88A1:
                        *str++ = '娃';
                        break;
                    case 0x88A2:
                        *str++ = '阿';
                        break;
                    case 0x88A3:
                        *str++ = '哀';
                        break;
                    case 0x88A4:
                        *str++ = '愛';
                        break;
                    case 0x88A5:
                        *str++ = '挨';
                        break;
                    case 0x88A6:
                        *str++ = '姶';
                        break;
                    case 0x88A7:
                        *str++ = '逢';
                        break;
                    case 0x88A8:
                        *str++ = '葵';
                        break;
                    case 0x88A9:
                        *str++ = '茜';
                        break;
                    case 0x88AA:
                        *str++ = '穐';
                        break;
                    case 0x88AB:
                        *str++ = '悪';
                        break;
                    case 0x88AC:
                        *str++ = '握';
                        break;
                    case 0x88AD:
                        *str++ = '渥';
                        break;
                    case 0x88AE:
                        *str++ = '旭';
                        break;
                    case 0x88AF:
                        *str++ = '葦';
                        break;
                    case 0x88B0:
                        *str++ = '芦';
                        break;
                    case 0x88B1:
                        *str++ = '鯵';
                        break;
                    case 0x88B2:
                        *str++ = '梓';
                        break;
                    case 0x88B3:
                        *str++ = '圧';
                        break;
                    case 0x88B4:
                        *str++ = '斡';
                        break;
                    case 0x88B5:
                        *str++ = '扱';
                        break;
                    case 0x88B6:
                        *str++ = '宛';
                        break;
                    case 0x88B7:
                        *str++ = '姐';
                        break;
                    case 0x88B8:
                        *str++ = '虻';
                        break;
                    case 0x88B9:
                        *str++ = '飴';
                        break;
                    case 0x88BA:
                        *str++ = '絢';
                        break;
                    case 0x88BB:
                        *str++ = '綾';
                        break;
                    case 0x88BC:
                        *str++ = '鮎';
                        break;
                    case 0x88BD:
                        *str++ = '或';
                        break;
                    case 0x88BE:
                        *str++ = '粟';
                        break;
                    case 0x88BF:
                        *str++ = '袷';
                        break;
                    case 0x88C0:
                        *str++ = '安';
                        break;
                    case 0x88C1:
                        *str++ = '庵';
                        break;
                    case 0x88C2:
                        *str++ = '按';
                        break;
                    case 0x88C3:
                        *str++ = '暗';
                        break;
                    case 0x88C4:
                        *str++ = '案';
                        break;
                    case 0x88C5:
                        *str++ = '闇';
                        break;
                    case 0x88C6:
                        *str++ = '鞍';
                        break;
                    case 0x88C7:
                        *str++ = '杏';
                        break;
                    case 0x88C8:
                        *str++ = '以';
                        break;
                    case 0x88C9:
                        *str++ = '伊';
                        break;
                    case 0x88CA:
                        *str++ = '位';
                        break;
                    case 0x88CB:
                        *str++ = '依';
                        break;
                    case 0x88CC:
                        *str++ = '偉';
                        break;
                    case 0x88CD:
                        *str++ = '囲';
                        break;
                    case 0x88CE:
                        *str++ = '夷';
                        break;
                    case 0x88CF:
                        *str++ = '委';
                        break;
                    case 0x88D0:
                        *str++ = '威';
                        break;
                    case 0x88D1:
                        *str++ = '尉';
                        break;
                    case 0x88D2:
                        *str++ = '惟';
                        break;
                    case 0x88D3:
                        *str++ = '意';
                        break;
                    case 0x88D4:
                        *str++ = '慰';
                        break;
                    case 0x88D5:
                        *str++ = '易';
                        break;
                    case 0x88D6:
                        *str++ = '椅';
                        break;
                    case 0x88D7:
                        *str++ = '為';
                        break;
                    case 0x88D8:
                        *str++ = '畏';
                        break;
                    case 0x88D9:
                        *str++ = '異';
                        break;
                    case 0x88DA:
                        *str++ = '移';
                        break;
                    case 0x88DB:
                        *str++ = '維';
                        break;
                    case 0x88DC:
                        *str++ = '緯';
                        break;
                    case 0x88DD:
                        *str++ = '胃';
                        break;
                    case 0x88DE:
                        *str++ = '萎';
                        break;
                    case 0x88DF:
                        *str++ = '衣';
                        break;
                    case 0x88E0:
                        *str++ = '謂';
                        break;
                    case 0x88E1:
                        *str++ = '違';
                        break;
                    case 0x88E2:
                        *str++ = '遺';
                        break;
                    case 0x88E3:
                        *str++ = '医';
                        break;
                    case 0x88E4:
                        *str++ = '井';
                        break;
                    case 0x88E5:
                        *str++ = '亥';
                        break;
                    case 0x88E6:
                        *str++ = '域';
                        break;
                    case 0x88E7:
                        *str++ = '育';
                        break;
                    case 0x88E8:
                        *str++ = '郁';
                        break;
                    case 0x88E9:
                        *str++ = '磯';
                        break;
                    case 0x88EA:
                        *str++ = '一';
                        break;
                    case 0x88EB:
                        *str++ = '壱';
                        break;
                    case 0x88EC:
                        *str++ = '溢';
                        break;
                    case 0x88ED:
                        *str++ = '逸';
                        break;
                    case 0x88EE:
                        *str++ = '稲';
                        break;
                    case 0x88EF:
                        *str++ = '茨';
                        break;
                    case 0x88F0:
                        *str++ = '芋';
                        break;
                    case 0x88F1:
                        *str++ = '鰯';
                        break;
                    case 0x88F2:
                        *str++ = '允';
                        break;
                    case 0x88F3:
                        *str++ = '印';
                        break;
                    case 0x88F4:
                        *str++ = '咽';
                        break;
                    case 0x88F5:
                        *str++ = '員';
                        break;
                    case 0x88F6:
                        *str++ = '因';
                        break;
                    case 0x88F7:
                        *str++ = '姻';
                        break;
                    case 0x88F8:
                        *str++ = '引';
                        break;
                    case 0x88F9:
                        *str++ = '飲';
                        break;
                    case 0x88FA:
                        *str++ = '淫';
                        break;
                    case 0x88FB:
                        *str++ = '胤';
                        break;
                    case 0x88FC:
                        *str++ = '蔭';
                        break;
                    case 0x8940:
                        *str++ = '院';
                        break;
                    case 0x8941:
                        *str++ = '陰';
                        break;
                    case 0x8942:
                        *str++ = '隠';
                        break;
                    case 0x8943:
                        *str++ = '韻';
                        break;
                    case 0x8944:
                        *str++ = '吋';
                        break;
                    case 0x8945:
                        *str++ = '右';
                        break;
                    case 0x8946:
                        *str++ = '宇';
                        break;
                    case 0x8947:
                        *str++ = '烏';
                        break;
                    case 0x8948:
                        *str++ = '羽';
                        break;
                    case 0x8949:
                        *str++ = '迂';
                        break;
                    case 0x894A:
                        *str++ = '雨';
                        break;
                    case 0x894B:
                        *str++ = '卯';
                        break;
                    case 0x894C:
                        *str++ = '鵜';
                        break;
                    case 0x894D:
                        *str++ = '窺';
                        break;
                    case 0x894E:
                        *str++ = '丑';
                        break;
                    case 0x894F:
                        *str++ = '碓';
                        break;
                    case 0x8950:
                        *str++ = '臼';
                        break;
                    case 0x8951:
                        *str++ = '渦';
                        break;
                    case 0x8952:
                        *str++ = '嘘';
                        break;
                    case 0x8953:
                        *str++ = '唄';
                        break;
                    case 0x8954:
                        *str++ = '欝';
                        break;
                    case 0x8955:
                        *str++ = '蔚';
                        break;
                    case 0x8956:
                        *str++ = '鰻';
                        break;
                    case 0x8957:
                        *str++ = '姥';
                        break;
                    case 0x8958:
                        *str++ = '厩';
                        break;
                    case 0x8959:
                        *str++ = '浦';
                        break;
                    case 0x895A:
                        *str++ = '瓜';
                        break;
                    case 0x895B:
                        *str++ = '閏';
                        break;
                    case 0x895C:
                        *str++ = '噂';
                        break;
                    case 0x895D:
                        *str++ = '云';
                        break;
                    case 0x895E:
                        *str++ = '運';
                        break;
                    case 0x895F:
                        *str++ = '雲';
                        break;
                    case 0x8960:
                        *str++ = '荏';
                        break;
                    case 0x8961:
                        *str++ = '餌';
                        break;
                    case 0x8962:
                        *str++ = '叡';
                        break;
                    case 0x8963:
                        *str++ = '営';
                        break;
                    case 0x8964:
                        *str++ = '嬰';
                        break;
                    case 0x8965:
                        *str++ = '影';
                        break;
                    case 0x8966:
                        *str++ = '映';
                        break;
                    case 0x8967:
                        *str++ = '曳';
                        break;
                    case 0x8968:
                        *str++ = '栄';
                        break;
                    case 0x8969:
                        *str++ = '永';
                        break;
                    case 0x896A:
                        *str++ = '泳';
                        break;
                    case 0x896B:
                        *str++ = '洩';
                        break;
                    case 0x896C:
                        *str++ = '瑛';
                        break;
                    case 0x896D:
                        *str++ = '盈';
                        break;
                    case 0x896E:
                        *str++ = '穎';
                        break;
                    case 0x896F:
                        *str++ = '頴';
                        break;
                    case 0x8970:
                        *str++ = '英';
                        break;
                    case 0x8971:
                        *str++ = '衛';
                        break;
                    case 0x8972:
                        *str++ = '詠';
                        break;
                    case 0x8973:
                        *str++ = '鋭';
                        break;
                    case 0x8974:
                        *str++ = '液';
                        break;
                    case 0x8975:
                        *str++ = '疫';
                        break;
                    case 0x8976:
                        *str++ = '益';
                        break;
                    case 0x8977:
                        *str++ = '駅';
                        break;
                    case 0x8978:
                        *str++ = '悦';
                        break;
                    case 0x8979:
                        *str++ = '謁';
                        break;
                    case 0x897A:
                        *str++ = '越';
                        break;
                    case 0x897B:
                        *str++ = '閲';
                        break;
                    case 0x897C:
                        *str++ = '榎';
                        break;
                    case 0x897D:
                        *str++ = '厭';
                        break;
                    case 0x897E:
                        *str++ = '円';
                        break;
                    case 0x8980:
                        *str++ = '園';
                        break;
                    case 0x8981:
                        *str++ = '堰';
                        break;
                    case 0x8982:
                        *str++ = '奄';
                        break;
                    case 0x8983:
                        *str++ = '宴';
                        break;
                    case 0x8984:
                        *str++ = '延';
                        break;
                    case 0x8985:
                        *str++ = '怨';
                        break;
                    case 0x8986:
                        *str++ = '掩';
                        break;
                    case 0x8987:
                        *str++ = '援';
                        break;
                    case 0x8988:
                        *str++ = '沿';
                        break;
                    case 0x8989:
                        *str++ = '演';
                        break;
                    case 0x898A:
                        *str++ = '炎';
                        break;
                    case 0x898B:
                        *str++ = '焔';
                        break;
                    case 0x898C:
                        *str++ = '煙';
                        break;
                    case 0x898D:
                        *str++ = '燕';
                        break;
                    case 0x898E:
                        *str++ = '猿';
                        break;
                    case 0x898F:
                        *str++ = '縁';
                        break;
                    case 0x8990:
                        *str++ = '艶';
                        break;
                    case 0x8991:
                        *str++ = '苑';
                        break;
                    case 0x8992:
                        *str++ = '薗';
                        break;
                    case 0x8993:
                        *str++ = '遠';
                        break;
                    case 0x8994:
                        *str++ = '鉛';
                        break;
                    case 0x8995:
                        *str++ = '鴛';
                        break;
                    case 0x8996:
                        *str++ = '塩';
                        break;
                    case 0x8997:
                        *str++ = '於';
                        break;
                    case 0x8998:
                        *str++ = '汚';
                        break;
                    case 0x8999:
                        *str++ = '甥';
                        break;
                    case 0x899A:
                        *str++ = '凹';
                        break;
                    case 0x899B:
                        *str++ = '央';
                        break;
                    case 0x899C:
                        *str++ = '奥';
                        break;
                    case 0x899D:
                        *str++ = '往';
                        break;
                    case 0x899E:
                        *str++ = '応';
                        break;
                    case 0x899F:
                        *str++ = '押';
                        break;
                    case 0x89A0:
                        *str++ = '旺';
                        break;
                    case 0x89A1:
                        *str++ = '横';
                        break;
                    case 0x89A2:
                        *str++ = '欧';
                        break;
                    case 0x89A3:
                        *str++ = '殴';
                        break;
                    case 0x89A4:
                        *str++ = '王';
                        break;
                    case 0x89A5:
                        *str++ = '翁';
                        break;
                    case 0x89A6:
                        *str++ = '襖';
                        break;
                    case 0x89A7:
                        *str++ = '鴬';
                        break;
                    case 0x89A8:
                        *str++ = '鴎';
                        break;
                    case 0x89A9:
                        *str++ = '黄';
                        break;
                    case 0x89AA:
                        *str++ = '岡';
                        break;
                    case 0x89AB:
                        *str++ = '沖';
                        break;
                    case 0x89AC:
                        *str++ = '荻';
                        break;
                    case 0x89AD:
                        *str++ = '億';
                        break;
                    case 0x89AE:
                        *str++ = '屋';
                        break;
                    case 0x89AF:
                        *str++ = '憶';
                        break;
                    case 0x89B0:
                        *str++ = '臆';
                        break;
                    case 0x89B1:
                        *str++ = '桶';
                        break;
                    case 0x89B2:
                        *str++ = '牡';
                        break;
                    case 0x89B3:
                        *str++ = '乙';
                        break;
                    case 0x89B4:
                        *str++ = '俺';
                        break;
                    case 0x89B5:
                        *str++ = '卸';
                        break;
                    case 0x89B6:
                        *str++ = '恩';
                        break;
                    case 0x89B7:
                        *str++ = '温';
                        break;
                    case 0x89B8:
                        *str++ = '穏';
                        break;
                    case 0x89B9:
                        *str++ = '音';
                        break;
                    case 0x89BA:
                        *str++ = '下';
                        break;
                    case 0x89BB:
                        *str++ = '化';
                        break;
                    case 0x89BC:
                        *str++ = '仮';
                        break;
                    case 0x89BD:
                        *str++ = '何';
                        break;
                    case 0x89BE:
                        *str++ = '伽';
                        break;
                    case 0x89BF:
                        *str++ = '価';
                        break;
                    case 0x89C0:
                        *str++ = '佳';
                        break;
                    case 0x89C1:
                        *str++ = '加';
                        break;
                    case 0x89C2:
                        *str++ = '可';
                        break;
                    case 0x89C3:
                        *str++ = '嘉';
                        break;
                    case 0x89C4:
                        *str++ = '夏';
                        break;
                    case 0x89C5:
                        *str++ = '嫁';
                        break;
                    case 0x89C6:
                        *str++ = '家';
                        break;
                    case 0x89C7:
                        *str++ = '寡';
                        break;
                    case 0x89C8:
                        *str++ = '科';
                        break;
                    case 0x89C9:
                        *str++ = '暇';
                        break;
                    case 0x89CA:
                        *str++ = '果';
                        break;
                    case 0x89CB:
                        *str++ = '架';
                        break;
                    case 0x89CC:
                        *str++ = '歌';
                        break;
                    case 0x89CD:
                        *str++ = '河';
                        break;
                    case 0x89CE:
                        *str++ = '火';
                        break;
                    case 0x89CF:
                        *str++ = '珂';
                        break;
                    case 0x89D0:
                        *str++ = '禍';
                        break;
                    case 0x89D1:
                        *str++ = '禾';
                        break;
                    case 0x89D2:
                        *str++ = '稼';
                        break;
                    case 0x89D3:
                        *str++ = '箇';
                        break;
                    case 0x89D4:
                        *str++ = '花';
                        break;
                    case 0x89D5:
                        *str++ = '苛';
                        break;
                    case 0x89D6:
                        *str++ = '茄';
                        break;
                    case 0x89D7:
                        *str++ = '荷';
                        break;
                    case 0x89D8:
                        *str++ = '華';
                        break;
                    case 0x89D9:
                        *str++ = '菓';
                        break;
                    case 0x89DA:
                        *str++ = '蝦';
                        break;
                    case 0x89DB:
                        *str++ = '課';
                        break;
                    case 0x89DC:
                        *str++ = '嘩';
                        break;
                    case 0x89DD:
                        *str++ = '貨';
                        break;
                    case 0x89DE:
                        *str++ = '迦';
                        break;
                    case 0x89DF:
                        *str++ = '過';
                        break;
                    case 0x89E0:
                        *str++ = '霞';
                        break;
                    case 0x89E1:
                        *str++ = '蚊';
                        break;
                    case 0x89E2:
                        *str++ = '俄';
                        break;
                    case 0x89E3:
                        *str++ = '峨';
                        break;
                    case 0x89E4:
                        *str++ = '我';
                        break;
                    case 0x89E5:
                        *str++ = '牙';
                        break;
                    case 0x89E6:
                        *str++ = '画';
                        break;
                    case 0x89E7:
                        *str++ = '臥';
                        break;
                    case 0x89E8:
                        *str++ = '芽';
                        break;
                    case 0x89E9:
                        *str++ = '蛾';
                        break;
                    case 0x89EA:
                        *str++ = '賀';
                        break;
                    case 0x89EB:
                        *str++ = '雅';
                        break;
                    case 0x89EC:
                        *str++ = '餓';
                        break;
                    case 0x89ED:
                        *str++ = '駕';
                        break;
                    case 0x89EE:
                        *str++ = '介';
                        break;
                    case 0x89EF:
                        *str++ = '会';
                        break;
                    case 0x89F0:
                        *str++ = '解';
                        break;
                    case 0x89F1:
                        *str++ = '回';
                        break;
                    case 0x89F2:
                        *str++ = '塊';
                        break;
                    case 0x89F3:
                        *str++ = '壊';
                        break;
                    case 0x89F4:
                        *str++ = '廻';
                        break;
                    case 0x89F5:
                        *str++ = '快';
                        break;
                    case 0x89F6:
                        *str++ = '怪';
                        break;
                    case 0x89F7:
                        *str++ = '悔';
                        break;
                    case 0x89F8:
                        *str++ = '恢';
                        break;
                    case 0x89F9:
                        *str++ = '懐';
                        break;
                    case 0x89FA:
                        *str++ = '戒';
                        break;
                    case 0x89FB:
                        *str++ = '拐';
                        break;
                    case 0x89FC:
                        *str++ = '改';
                        break;
                    case 0x8A40:
                        *str++ = '魁';
                        break;
                    case 0x8A41:
                        *str++ = '晦';
                        break;
                    case 0x8A42:
                        *str++ = '械';
                        break;
                    case 0x8A43:
                        *str++ = '海';
                        break;
                    case 0x8A44:
                        *str++ = '灰';
                        break;
                    case 0x8A45:
                        *str++ = '界';
                        break;
                    case 0x8A46:
                        *str++ = '皆';
                        break;
                    case 0x8A47:
                        *str++ = '絵';
                        break;
                    case 0x8A48:
                        *str++ = '芥';
                        break;
                    case 0x8A49:
                        *str++ = '蟹';
                        break;
                    case 0x8A4A:
                        *str++ = '開';
                        break;
                    case 0x8A4B:
                        *str++ = '階';
                        break;
                    case 0x8A4C:
                        *str++ = '貝';
                        break;
                    case 0x8A4D:
                        *str++ = '凱';
                        break;
                    case 0x8A4E:
                        *str++ = '劾';
                        break;
                    case 0x8A4F:
                        *str++ = '外';
                        break;
                    case 0x8A50:
                        *str++ = '咳';
                        break;
                    case 0x8A51:
                        *str++ = '害';
                        break;
                    case 0x8A52:
                        *str++ = '崖';
                        break;
                    case 0x8A53:
                        *str++ = '慨';
                        break;
                    case 0x8A54:
                        *str++ = '概';
                        break;
                    case 0x8A55:
                        *str++ = '涯';
                        break;
                    case 0x8A56:
                        *str++ = '碍';
                        break;
                    case 0x8A57:
                        *str++ = '蓋';
                        break;
                    case 0x8A58:
                        *str++ = '街';
                        break;
                    case 0x8A59:
                        *str++ = '該';
                        break;
                    case 0x8A5A:
                        *str++ = '鎧';
                        break;
                    case 0x8A5B:
                        *str++ = '骸';
                        break;
                    case 0x8A5C:
                        *str++ = '浬';
                        break;
                    case 0x8A5D:
                        *str++ = '馨';
                        break;
                    case 0x8A5E:
                        *str++ = '蛙';
                        break;
                    case 0x8A5F:
                        *str++ = '垣';
                        break;
                    case 0x8A60:
                        *str++ = '柿';
                        break;
                    case 0x8A61:
                        *str++ = '蛎';
                        break;
                    case 0x8A62:
                        *str++ = '鈎';
                        break;
                    case 0x8A63:
                        *str++ = '劃';
                        break;
                    case 0x8A64:
                        *str++ = '嚇';
                        break;
                    case 0x8A65:
                        *str++ = '各';
                        break;
                    case 0x8A66:
                        *str++ = '廓';
                        break;
                    case 0x8A67:
                        *str++ = '拡';
                        break;
                    case 0x8A68:
                        *str++ = '撹';
                        break;
                    case 0x8A69:
                        *str++ = '格';
                        break;
                    case 0x8A6A:
                        *str++ = '核';
                        break;
                    case 0x8A6B:
                        *str++ = '殻';
                        break;
                    case 0x8A6C:
                        *str++ = '獲';
                        break;
                    case 0x8A6D:
                        *str++ = '確';
                        break;
                    case 0x8A6E:
                        *str++ = '穫';
                        break;
                    case 0x8A6F:
                        *str++ = '覚';
                        break;
                    case 0x8A70:
                        *str++ = '角';
                        break;
                    case 0x8A71:
                        *str++ = '赫';
                        break;
                    case 0x8A72:
                        *str++ = '較';
                        break;
                    case 0x8A73:
                        *str++ = '郭';
                        break;
                    case 0x8A74:
                        *str++ = '閣';
                        break;
                    case 0x8A75:
                        *str++ = '隔';
                        break;
                    case 0x8A76:
                        *str++ = '革';
                        break;
                    case 0x8A77:
                        *str++ = '学';
                        break;
                    case 0x8A78:
                        *str++ = '岳';
                        break;
                    case 0x8A79:
                        *str++ = '楽';
                        break;
                    case 0x8A7A:
                        *str++ = '額';
                        break;
                    case 0x8A7B:
                        *str++ = '顎';
                        break;
                    case 0x8A7C:
                        *str++ = '掛';
                        break;
                    case 0x8A7D:
                        *str++ = '笠';
                        break;
                    case 0x8A7E:
                        *str++ = '樫';
                        break;
                    case 0x8A80:
                        *str++ = '橿';
                        break;
                    case 0x8A81:
                        *str++ = '梶';
                        break;
                    case 0x8A82:
                        *str++ = '鰍';
                        break;
                    case 0x8A83:
                        *str++ = '潟';
                        break;
                    case 0x8A84:
                        *str++ = '割';
                        break;
                    case 0x8A85:
                        *str++ = '喝';
                        break;
                    case 0x8A86:
                        *str++ = '恰';
                        break;
                    case 0x8A87:
                        *str++ = '括';
                        break;
                    case 0x8A88:
                        *str++ = '活';
                        break;
                    case 0x8A89:
                        *str++ = '渇';
                        break;
                    case 0x8A8A:
                        *str++ = '滑';
                        break;
                    case 0x8A8B:
                        *str++ = '葛';
                        break;
                    case 0x8A8C:
                        *str++ = '褐';
                        break;
                    case 0x8A8D:
                        *str++ = '轄';
                        break;
                    case 0x8A8E:
                        *str++ = '且';
                        break;
                    case 0x8A8F:
                        *str++ = '鰹';
                        break;
                    case 0x8A90:
                        *str++ = '叶';
                        break;
                    case 0x8A91:
                        *str++ = '椛';
                        break;
                    case 0x8A92:
                        *str++ = '樺';
                        break;
                    case 0x8A93:
                        *str++ = '鞄';
                        break;
                    case 0x8A94:
                        *str++ = '株';
                        break;
                    case 0x8A95:
                        *str++ = '兜';
                        break;
                    case 0x8A96:
                        *str++ = '竃';
                        break;
                    case 0x8A97:
                        *str++ = '蒲';
                        break;
                    case 0x8A98:
                        *str++ = '釜';
                        break;
                    case 0x8A99:
                        *str++ = '鎌';
                        break;
                    case 0x8A9A:
                        *str++ = '噛';
                        break;
                    case 0x8A9B:
                        *str++ = '鴨';
                        break;
                    case 0x8A9C:
                        *str++ = '栢';
                        break;
                    case 0x8A9D:
                        *str++ = '茅';
                        break;
                    case 0x8A9E:
                        *str++ = '萱';
                        break;
                    case 0x8A9F:
                        *str++ = '粥';
                        break;
                    case 0x8AA0:
                        *str++ = '刈';
                        break;
                    case 0x8AA1:
                        *str++ = '苅';
                        break;
                    case 0x8AA2:
                        *str++ = '瓦';
                        break;
                    case 0x8AA3:
                        *str++ = '乾';
                        break;
                    case 0x8AA4:
                        *str++ = '侃';
                        break;
                    case 0x8AA5:
                        *str++ = '冠';
                        break;
                    case 0x8AA6:
                        *str++ = '寒';
                        break;
                    case 0x8AA7:
                        *str++ = '刊';
                        break;
                    case 0x8AA8:
                        *str++ = '勘';
                        break;
                    case 0x8AA9:
                        *str++ = '勧';
                        break;
                    case 0x8AAA:
                        *str++ = '巻';
                        break;
                    case 0x8AAB:
                        *str++ = '喚';
                        break;
                    case 0x8AAC:
                        *str++ = '堪';
                        break;
                    case 0x8AAD:
                        *str++ = '姦';
                        break;
                    case 0x8AAE:
                        *str++ = '完';
                        break;
                    case 0x8AAF:
                        *str++ = '官';
                        break;
                    case 0x8AB0:
                        *str++ = '寛';
                        break;
                    case 0x8AB1:
                        *str++ = '干';
                        break;
                    case 0x8AB2:
                        *str++ = '幹';
                        break;
                    case 0x8AB3:
                        *str++ = '患';
                        break;
                    case 0x8AB4:
                        *str++ = '感';
                        break;
                    case 0x8AB5:
                        *str++ = '慣';
                        break;
                    case 0x8AB6:
                        *str++ = '憾';
                        break;
                    case 0x8AB7:
                        *str++ = '換';
                        break;
                    case 0x8AB8:
                        *str++ = '敢';
                        break;
                    case 0x8AB9:
                        *str++ = '柑';
                        break;
                    case 0x8ABA:
                        *str++ = '桓';
                        break;
                    case 0x8ABB:
                        *str++ = '棺';
                        break;
                    case 0x8ABC:
                        *str++ = '款';
                        break;
                    case 0x8ABD:
                        *str++ = '歓';
                        break;
                    case 0x8ABE:
                        *str++ = '汗';
                        break;
                    case 0x8ABF:
                        *str++ = '漢';
                        break;
                    case 0x8AC0:
                        *str++ = '澗';
                        break;
                    case 0x8AC1:
                        *str++ = '潅';
                        break;
                    case 0x8AC2:
                        *str++ = '環';
                        break;
                    case 0x8AC3:
                        *str++ = '甘';
                        break;
                    case 0x8AC4:
                        *str++ = '監';
                        break;
                    case 0x8AC5:
                        *str++ = '看';
                        break;
                    case 0x8AC6:
                        *str++ = '竿';
                        break;
                    case 0x8AC7:
                        *str++ = '管';
                        break;
                    case 0x8AC8:
                        *str++ = '簡';
                        break;
                    case 0x8AC9:
                        *str++ = '緩';
                        break;
                    case 0x8ACA:
                        *str++ = '缶';
                        break;
                    case 0x8ACB:
                        *str++ = '翰';
                        break;
                    case 0x8ACC:
                        *str++ = '肝';
                        break;
                    case 0x8ACD:
                        *str++ = '艦';
                        break;
                    case 0x8ACE:
                        *str++ = '莞';
                        break;
                    case 0x8ACF:
                        *str++ = '観';
                        break;
                    case 0x8AD0:
                        *str++ = '諌';
                        break;
                    case 0x8AD1:
                        *str++ = '貫';
                        break;
                    case 0x8AD2:
                        *str++ = '還';
                        break;
                    case 0x8AD3:
                        *str++ = '鑑';
                        break;
                    case 0x8AD4:
                        *str++ = '間';
                        break;
                    case 0x8AD5:
                        *str++ = '閑';
                        break;
                    case 0x8AD6:
                        *str++ = '関';
                        break;
                    case 0x8AD7:
                        *str++ = '陥';
                        break;
                    case 0x8AD8:
                        *str++ = '韓';
                        break;
                    case 0x8AD9:
                        *str++ = '館';
                        break;
                    case 0x8ADA:
                        *str++ = '舘';
                        break;
                    case 0x8ADB:
                        *str++ = '丸';
                        break;
                    case 0x8ADC:
                        *str++ = '含';
                        break;
                    case 0x8ADD:
                        *str++ = '岸';
                        break;
                    case 0x8ADE:
                        *str++ = '巌';
                        break;
                    case 0x8ADF:
                        *str++ = '玩';
                        break;
                    case 0x8AE0:
                        *str++ = '癌';
                        break;
                    case 0x8AE1:
                        *str++ = '眼';
                        break;
                    case 0x8AE2:
                        *str++ = '岩';
                        break;
                    case 0x8AE3:
                        *str++ = '翫';
                        break;
                    case 0x8AE4:
                        *str++ = '贋';
                        break;
                    case 0x8AE5:
                        *str++ = '雁';
                        break;
                    case 0x8AE6:
                        *str++ = '頑';
                        break;
                    case 0x8AE7:
                        *str++ = '顔';
                        break;
                    case 0x8AE8:
                        *str++ = '願';
                        break;
                    case 0x8AE9:
                        *str++ = '企';
                        break;
                    case 0x8AEA:
                        *str++ = '伎';
                        break;
                    case 0x8AEB:
                        *str++ = '危';
                        break;
                    case 0x8AEC:
                        *str++ = '喜';
                        break;
                    case 0x8AED:
                        *str++ = '器';
                        break;
                    case 0x8AEE:
                        *str++ = '基';
                        break;
                    case 0x8AEF:
                        *str++ = '奇';
                        break;
                    case 0x8AF0:
                        *str++ = '嬉';
                        break;
                    case 0x8AF1:
                        *str++ = '寄';
                        break;
                    case 0x8AF2:
                        *str++ = '岐';
                        break;
                    case 0x8AF3:
                        *str++ = '希';
                        break;
                    case 0x8AF4:
                        *str++ = '幾';
                        break;
                    case 0x8AF5:
                        *str++ = '忌';
                        break;
                    case 0x8AF6:
                        *str++ = '揮';
                        break;
                    case 0x8AF7:
                        *str++ = '机';
                        break;
                    case 0x8AF8:
                        *str++ = '旗';
                        break;
                    case 0x8AF9:
                        *str++ = '既';
                        break;
                    case 0x8AFA:
                        *str++ = '期';
                        break;
                    case 0x8AFB:
                        *str++ = '棋';
                        break;
                    case 0x8AFC:
                        *str++ = '棄';
                        break;
                    case 0x8B40:
                        *str++ = '機';
                        break;
                    case 0x8B41:
                        *str++ = '帰';
                        break;
                    case 0x8B42:
                        *str++ = '毅';
                        break;
                    case 0x8B43:
                        *str++ = '気';
                        break;
                    case 0x8B44:
                        *str++ = '汽';
                        break;
                    case 0x8B45:
                        *str++ = '畿';
                        break;
                    case 0x8B46:
                        *str++ = '祈';
                        break;
                    case 0x8B47:
                        *str++ = '季';
                        break;
                    case 0x8B48:
                        *str++ = '稀';
                        break;
                    case 0x8B49:
                        *str++ = '紀';
                        break;
                    case 0x8B4A:
                        *str++ = '徽';
                        break;
                    case 0x8B4B:
                        *str++ = '規';
                        break;
                    case 0x8B4C:
                        *str++ = '記';
                        break;
                    case 0x8B4D:
                        *str++ = '貴';
                        break;
                    case 0x8B4E:
                        *str++ = '起';
                        break;
                    case 0x8B4F:
                        *str++ = '軌';
                        break;
                    case 0x8B50:
                        *str++ = '輝';
                        break;
                    case 0x8B51:
                        *str++ = '飢';
                        break;
                    case 0x8B52:
                        *str++ = '騎';
                        break;
                    case 0x8B53:
                        *str++ = '鬼';
                        break;
                    case 0x8B54:
                        *str++ = '亀';
                        break;
                    case 0x8B55:
                        *str++ = '偽';
                        break;
                    case 0x8B56:
                        *str++ = '儀';
                        break;
                    case 0x8B57:
                        *str++ = '妓';
                        break;
                    case 0x8B58:
                        *str++ = '宜';
                        break;
                    case 0x8B59:
                        *str++ = '戯';
                        break;
                    case 0x8B5A:
                        *str++ = '技';
                        break;
                    case 0x8B5B:
                        *str++ = '擬';
                        break;
                    case 0x8B5C:
                        *str++ = '欺';
                        break;
                    case 0x8B5D:
                        *str++ = '犠';
                        break;
                    case 0x8B5E:
                        *str++ = '疑';
                        break;
                    case 0x8B5F:
                        *str++ = '祇';
                        break;
                    case 0x8B60:
                        *str++ = '義';
                        break;
                    case 0x8B61:
                        *str++ = '蟻';
                        break;
                    case 0x8B62:
                        *str++ = '誼';
                        break;
                    case 0x8B63:
                        *str++ = '議';
                        break;
                    case 0x8B64:
                        *str++ = '掬';
                        break;
                    case 0x8B65:
                        *str++ = '菊';
                        break;
                    case 0x8B66:
                        *str++ = '鞠';
                        break;
                    case 0x8B67:
                        *str++ = '吉';
                        break;
                    case 0x8B68:
                        *str++ = '吃';
                        break;
                    case 0x8B69:
                        *str++ = '喫';
                        break;
                    case 0x8B6A:
                        *str++ = '桔';
                        break;
                    case 0x8B6B:
                        *str++ = '橘';
                        break;
                    case 0x8B6C:
                        *str++ = '詰';
                        break;
                    case 0x8B6D:
                        *str++ = '砧';
                        break;
                    case 0x8B6E:
                        *str++ = '杵';
                        break;
                    case 0x8B6F:
                        *str++ = '黍';
                        break;
                    case 0x8B70:
                        *str++ = '却';
                        break;
                    case 0x8B71:
                        *str++ = '客';
                        break;
                    case 0x8B72:
                        *str++ = '脚';
                        break;
                    case 0x8B73:
                        *str++ = '虐';
                        break;
                    case 0x8B74:
                        *str++ = '逆';
                        break;
                    case 0x8B75:
                        *str++ = '丘';
                        break;
                    case 0x8B76:
                        *str++ = '久';
                        break;
                    case 0x8B77:
                        *str++ = '仇';
                        break;
                    case 0x8B78:
                        *str++ = '休';
                        break;
                    case 0x8B79:
                        *str++ = '及';
                        break;
                    case 0x8B7A:
                        *str++ = '吸';
                        break;
                    case 0x8B7B:
                        *str++ = '宮';
                        break;
                    case 0x8B7C:
                        *str++ = '弓';
                        break;
                    case 0x8B7D:
                        *str++ = '急';
                        break;
                    case 0x8B7E:
                        *str++ = '救';
                        break;
                    case 0x8B80:
                        *str++ = '朽';
                        break;
                    case 0x8B81:
                        *str++ = '求';
                        break;
                    case 0x8B82:
                        *str++ = '汲';
                        break;
                    case 0x8B83:
                        *str++ = '泣';
                        break;
                    case 0x8B84:
                        *str++ = '灸';
                        break;
                    case 0x8B85:
                        *str++ = '球';
                        break;
                    case 0x8B86:
                        *str++ = '究';
                        break;
                    case 0x8B87:
                        *str++ = '窮';
                        break;
                    case 0x8B88:
                        *str++ = '笈';
                        break;
                    case 0x8B89:
                        *str++ = '級';
                        break;
                    case 0x8B8A:
                        *str++ = '糾';
                        break;
                    case 0x8B8B:
                        *str++ = '給';
                        break;
                    case 0x8B8C:
                        *str++ = '旧';
                        break;
                    case 0x8B8D:
                        *str++ = '牛';
                        break;
                    case 0x8B8E:
                        *str++ = '去';
                        break;
                    case 0x8B8F:
                        *str++ = '居';
                        break;
                    case 0x8B90:
                        *str++ = '巨';
                        break;
                    case 0x8B91:
                        *str++ = '拒';
                        break;
                    case 0x8B92:
                        *str++ = '拠';
                        break;
                    case 0x8B93:
                        *str++ = '挙';
                        break;
                    case 0x8B94:
                        *str++ = '渠';
                        break;
                    case 0x8B95:
                        *str++ = '虚';
                        break;
                    case 0x8B96:
                        *str++ = '許';
                        break;
                    case 0x8B97:
                        *str++ = '距';
                        break;
                    case 0x8B98:
                        *str++ = '鋸';
                        break;
                    case 0x8B99:
                        *str++ = '漁';
                        break;
                    case 0x8B9A:
                        *str++ = '禦';
                        break;
                    case 0x8B9B:
                        *str++ = '魚';
                        break;
                    case 0x8B9C:
                        *str++ = '亨';
                        break;
                    case 0x8B9D:
                        *str++ = '享';
                        break;
                    case 0x8B9E:
                        *str++ = '京';
                        break;
                    case 0x8B9F:
                        *str++ = '供';
                        break;
                    case 0x8BA0:
                        *str++ = '侠';
                        break;
                    case 0x8BA1:
                        *str++ = '僑';
                        break;
                    case 0x8BA2:
                        *str++ = '兇';
                        break;
                    case 0x8BA3:
                        *str++ = '競';
                        break;
                    case 0x8BA4:
                        *str++ = '共';
                        break;
                    case 0x8BA5:
                        *str++ = '凶';
                        break;
                    case 0x8BA6:
                        *str++ = '協';
                        break;
                    case 0x8BA7:
                        *str++ = '匡';
                        break;
                    case 0x8BA8:
                        *str++ = '卿';
                        break;
                    case 0x8BA9:
                        *str++ = '叫';
                        break;
                    case 0x8BAA:
                        *str++ = '喬';
                        break;
                    case 0x8BAB:
                        *str++ = '境';
                        break;
                    case 0x8BAC:
                        *str++ = '峡';
                        break;
                    case 0x8BAD:
                        *str++ = '強';
                        break;
                    case 0x8BAE:
                        *str++ = '彊';
                        break;
                    case 0x8BAF:
                        *str++ = '怯';
                        break;
                    case 0x8BB0:
                        *str++ = '恐';
                        break;
                    case 0x8BB1:
                        *str++ = '恭';
                        break;
                    case 0x8BB2:
                        *str++ = '挟';
                        break;
                    case 0x8BB3:
                        *str++ = '教';
                        break;
                    case 0x8BB4:
                        *str++ = '橋';
                        break;
                    case 0x8BB5:
                        *str++ = '況';
                        break;
                    case 0x8BB6:
                        *str++ = '狂';
                        break;
                    case 0x8BB7:
                        *str++ = '狭';
                        break;
                    case 0x8BB8:
                        *str++ = '矯';
                        break;
                    case 0x8BB9:
                        *str++ = '胸';
                        break;
                    case 0x8BBA:
                        *str++ = '脅';
                        break;
                    case 0x8BBB:
                        *str++ = '興';
                        break;
                    case 0x8BBC:
                        *str++ = '蕎';
                        break;
                    case 0x8BBD:
                        *str++ = '郷';
                        break;
                    case 0x8BBE:
                        *str++ = '鏡';
                        break;
                    case 0x8BBF:
                        *str++ = '響';
                        break;
                    case 0x8BC0:
                        *str++ = '饗';
                        break;
                    case 0x8BC1:
                        *str++ = '驚';
                        break;
                    case 0x8BC2:
                        *str++ = '仰';
                        break;
                    case 0x8BC3:
                        *str++ = '凝';
                        break;
                    case 0x8BC4:
                        *str++ = '尭';
                        break;
                    case 0x8BC5:
                        *str++ = '暁';
                        break;
                    case 0x8BC6:
                        *str++ = '業';
                        break;
                    case 0x8BC7:
                        *str++ = '局';
                        break;
                    case 0x8BC8:
                        *str++ = '曲';
                        break;
                    case 0x8BC9:
                        *str++ = '極';
                        break;
                    case 0x8BCA:
                        *str++ = '玉';
                        break;
                    case 0x8BCB:
                        *str++ = '桐';
                        break;
                    case 0x8BCC:
                        *str++ = '粁';
                        break;
                    case 0x8BCD:
                        *str++ = '僅';
                        break;
                    case 0x8BCE:
                        *str++ = '勤';
                        break;
                    case 0x8BCF:
                        *str++ = '均';
                        break;
                    case 0x8BD0:
                        *str++ = '巾';
                        break;
                    case 0x8BD1:
                        *str++ = '錦';
                        break;
                    case 0x8BD2:
                        *str++ = '斤';
                        break;
                    case 0x8BD3:
                        *str++ = '欣';
                        break;
                    case 0x8BD4:
                        *str++ = '欽';
                        break;
                    case 0x8BD5:
                        *str++ = '琴';
                        break;
                    case 0x8BD6:
                        *str++ = '禁';
                        break;
                    case 0x8BD7:
                        *str++ = '禽';
                        break;
                    case 0x8BD8:
                        *str++ = '筋';
                        break;
                    case 0x8BD9:
                        *str++ = '緊';
                        break;
                    case 0x8BDA:
                        *str++ = '芹';
                        break;
                    case 0x8BDB:
                        *str++ = '菌';
                        break;
                    case 0x8BDC:
                        *str++ = '衿';
                        break;
                    case 0x8BDD:
                        *str++ = '襟';
                        break;
                    case 0x8BDE:
                        *str++ = '謹';
                        break;
                    case 0x8BDF:
                        *str++ = '近';
                        break;
                    case 0x8BE0:
                        *str++ = '金';
                        break;
                    case 0x8BE1:
                        *str++ = '吟';
                        break;
                    case 0x8BE2:
                        *str++ = '銀';
                        break;
                    case 0x8BE3:
                        *str++ = '九';
                        break;
                    case 0x8BE4:
                        *str++ = '倶';
                        break;
                    case 0x8BE5:
                        *str++ = '句';
                        break;
                    case 0x8BE6:
                        *str++ = '区';
                        break;
                    case 0x8BE7:
                        *str++ = '狗';
                        break;
                    case 0x8BE8:
                        *str++ = '玖';
                        break;
                    case 0x8BE9:
                        *str++ = '矩';
                        break;
                    case 0x8BEA:
                        *str++ = '苦';
                        break;
                    case 0x8BEB:
                        *str++ = '躯';
                        break;
                    case 0x8BEC:
                        *str++ = '駆';
                        break;
                    case 0x8BED:
                        *str++ = '駈';
                        break;
                    case 0x8BEE:
                        *str++ = '駒';
                        break;
                    case 0x8BEF:
                        *str++ = '具';
                        break;
                    case 0x8BF0:
                        *str++ = '愚';
                        break;
                    case 0x8BF1:
                        *str++ = '虞';
                        break;
                    case 0x8BF2:
                        *str++ = '喰';
                        break;
                    case 0x8BF3:
                        *str++ = '空';
                        break;
                    case 0x8BF4:
                        *str++ = '偶';
                        break;
                    case 0x8BF5:
                        *str++ = '寓';
                        break;
                    case 0x8BF6:
                        *str++ = '遇';
                        break;
                    case 0x8BF7:
                        *str++ = '隅';
                        break;
                    case 0x8BF8:
                        *str++ = '串';
                        break;
                    case 0x8BF9:
                        *str++ = '櫛';
                        break;
                    case 0x8BFA:
                        *str++ = '釧';
                        break;
                    case 0x8BFB:
                        *str++ = '屑';
                        break;
                    case 0x8BFC:
                        *str++ = '屈';
                        break;
                    case 0x8C40:
                        *str++ = '掘';
                        break;
                    case 0x8C41:
                        *str++ = '窟';
                        break;
                    case 0x8C42:
                        *str++ = '沓';
                        break;
                    case 0x8C43:
                        *str++ = '靴';
                        break;
                    case 0x8C44:
                        *str++ = '轡';
                        break;
                    case 0x8C45:
                        *str++ = '窪';
                        break;
                    case 0x8C46:
                        *str++ = '熊';
                        break;
                    case 0x8C47:
                        *str++ = '隈';
                        break;
                    case 0x8C48:
                        *str++ = '粂';
                        break;
                    case 0x8C49:
                        *str++ = '栗';
                        break;
                    case 0x8C4A:
                        *str++ = '繰';
                        break;
                    case 0x8C4B:
                        *str++ = '桑';
                        break;
                    case 0x8C4C:
                        *str++ = '鍬';
                        break;
                    case 0x8C4D:
                        *str++ = '勲';
                        break;
                    case 0x8C4E:
                        *str++ = '君';
                        break;
                    case 0x8C4F:
                        *str++ = '薫';
                        break;
                    case 0x8C50:
                        *str++ = '訓';
                        break;
                    case 0x8C51:
                        *str++ = '群';
                        break;
                    case 0x8C52:
                        *str++ = '軍';
                        break;
                    case 0x8C53:
                        *str++ = '郡';
                        break;
                    case 0x8C54:
                        *str++ = '卦';
                        break;
                    case 0x8C55:
                        *str++ = '袈';
                        break;
                    case 0x8C56:
                        *str++ = '祁';
                        break;
                    case 0x8C57:
                        *str++ = '係';
                        break;
                    case 0x8C58:
                        *str++ = '傾';
                        break;
                    case 0x8C59:
                        *str++ = '刑';
                        break;
                    case 0x8C5A:
                        *str++ = '兄';
                        break;
                    case 0x8C5B:
                        *str++ = '啓';
                        break;
                    case 0x8C5C:
                        *str++ = '圭';
                        break;
                    case 0x8C5D:
                        *str++ = '珪';
                        break;
                    case 0x8C5E:
                        *str++ = '型';
                        break;
                    case 0x8C5F:
                        *str++ = '契';
                        break;
                    case 0x8C60:
                        *str++ = '形';
                        break;
                    case 0x8C61:
                        *str++ = '径';
                        break;
                    case 0x8C62:
                        *str++ = '恵';
                        break;
                    case 0x8C63:
                        *str++ = '慶';
                        break;
                    case 0x8C64:
                        *str++ = '慧';
                        break;
                    case 0x8C65:
                        *str++ = '憩';
                        break;
                    case 0x8C66:
                        *str++ = '掲';
                        break;
                    case 0x8C67:
                        *str++ = '携';
                        break;
                    case 0x8C68:
                        *str++ = '敬';
                        break;
                    case 0x8C69:
                        *str++ = '景';
                        break;
                    case 0x8C6A:
                        *str++ = '桂';
                        break;
                    case 0x8C6B:
                        *str++ = '渓';
                        break;
                    case 0x8C6C:
                        *str++ = '畦';
                        break;
                    case 0x8C6D:
                        *str++ = '稽';
                        break;
                    case 0x8C6E:
                        *str++ = '系';
                        break;
                    case 0x8C6F:
                        *str++ = '経';
                        break;
                    case 0x8C70:
                        *str++ = '継';
                        break;
                    case 0x8C71:
                        *str++ = '繋';
                        break;
                    case 0x8C72:
                        *str++ = '罫';
                        break;
                    case 0x8C73:
                        *str++ = '茎';
                        break;
                    case 0x8C74:
                        *str++ = '荊';
                        break;
                    case 0x8C75:
                        *str++ = '蛍';
                        break;
                    case 0x8C76:
                        *str++ = '計';
                        break;
                    case 0x8C77:
                        *str++ = '詣';
                        break;
                    case 0x8C78:
                        *str++ = '警';
                        break;
                    case 0x8C79:
                        *str++ = '軽';
                        break;
                    case 0x8C7A:
                        *str++ = '頚';
                        break;
                    case 0x8C7B:
                        *str++ = '鶏';
                        break;
                    case 0x8C7C:
                        *str++ = '芸';
                        break;
                    case 0x8C7D:
                        *str++ = '迎';
                        break;
                    case 0x8C7E:
                        *str++ = '鯨';
                        break;
                    case 0x8C80:
                        *str++ = '劇';
                        break;
                    case 0x8C81:
                        *str++ = '戟';
                        break;
                    case 0x8C82:
                        *str++ = '撃';
                        break;
                    case 0x8C83:
                        *str++ = '激';
                        break;
                    case 0x8C84:
                        *str++ = '隙';
                        break;
                    case 0x8C85:
                        *str++ = '桁';
                        break;
                    case 0x8C86:
                        *str++ = '傑';
                        break;
                    case 0x8C87:
                        *str++ = '欠';
                        break;
                    case 0x8C88:
                        *str++ = '決';
                        break;
                    case 0x8C89:
                        *str++ = '潔';
                        break;
                    case 0x8C8A:
                        *str++ = '穴';
                        break;
                    case 0x8C8B:
                        *str++ = '結';
                        break;
                    case 0x8C8C:
                        *str++ = '血';
                        break;
                    case 0x8C8D:
                        *str++ = '訣';
                        break;
                    case 0x8C8E:
                        *str++ = '月';
                        break;
                    case 0x8C8F:
                        *str++ = '件';
                        break;
                    case 0x8C90:
                        *str++ = '倹';
                        break;
                    case 0x8C91:
                        *str++ = '倦';
                        break;
                    case 0x8C92:
                        *str++ = '健';
                        break;
                    case 0x8C93:
                        *str++ = '兼';
                        break;
                    case 0x8C94:
                        *str++ = '券';
                        break;
                    case 0x8C95:
                        *str++ = '剣';
                        break;
                    case 0x8C96:
                        *str++ = '喧';
                        break;
                    case 0x8C97:
                        *str++ = '圏';
                        break;
                    case 0x8C98:
                        *str++ = '堅';
                        break;
                    case 0x8C99:
                        *str++ = '嫌';
                        break;
                    case 0x8C9A:
                        *str++ = '建';
                        break;
                    case 0x8C9B:
                        *str++ = '憲';
                        break;
                    case 0x8C9C:
                        *str++ = '懸';
                        break;
                    case 0x8C9D:
                        *str++ = '拳';
                        break;
                    case 0x8C9E:
                        *str++ = '捲';
                        break;
                    case 0x8C9F:
                        *str++ = '検';
                        break;
                    case 0x8CA0:
                        *str++ = '権';
                        break;
                    case 0x8CA1:
                        *str++ = '牽';
                        break;
                    case 0x8CA2:
                        *str++ = '犬';
                        break;
                    case 0x8CA3:
                        *str++ = '献';
                        break;
                    case 0x8CA4:
                        *str++ = '研';
                        break;
                    case 0x8CA5:
                        *str++ = '硯';
                        break;
                    case 0x8CA6:
                        *str++ = '絹';
                        break;
                    case 0x8CA7:
                        *str++ = '県';
                        break;
                    case 0x8CA8:
                        *str++ = '肩';
                        break;
                    case 0x8CA9:
                        *str++ = '見';
                        break;
                    case 0x8CAA:
                        *str++ = '謙';
                        break;
                    case 0x8CAB:
                        *str++ = '賢';
                        break;
                    case 0x8CAC:
                        *str++ = '軒';
                        break;
                    case 0x8CAD:
                        *str++ = '遣';
                        break;
                    case 0x8CAE:
                        *str++ = '鍵';
                        break;
                    case 0x8CAF:
                        *str++ = '険';
                        break;
                    case 0x8CB0:
                        *str++ = '顕';
                        break;
                    case 0x8CB1:
                        *str++ = '験';
                        break;
                    case 0x8CB2:
                        *str++ = '鹸';
                        break;
                    case 0x8CB3:
                        *str++ = '元';
                        break;
                    case 0x8CB4:
                        *str++ = '原';
                        break;
                    case 0x8CB5:
                        *str++ = '厳';
                        break;
                    case 0x8CB6:
                        *str++ = '幻';
                        break;
                    case 0x8CB7:
                        *str++ = '弦';
                        break;
                    case 0x8CB8:
                        *str++ = '減';
                        break;
                    case 0x8CB9:
                        *str++ = '源';
                        break;
                    case 0x8CBA:
                        *str++ = '玄';
                        break;
                    case 0x8CBB:
                        *str++ = '現';
                        break;
                    case 0x8CBC:
                        *str++ = '絃';
                        break;
                    case 0x8CBD:
                        *str++ = '舷';
                        break;
                    case 0x8CBE:
                        *str++ = '言';
                        break;
                    case 0x8CBF:
                        *str++ = '諺';
                        break;
                    case 0x8CC0:
                        *str++ = '限';
                        break;
                    case 0x8CC1:
                        *str++ = '乎';
                        break;
                    case 0x8CC2:
                        *str++ = '個';
                        break;
                    case 0x8CC3:
                        *str++ = '古';
                        break;
                    case 0x8CC4:
                        *str++ = '呼';
                        break;
                    case 0x8CC5:
                        *str++ = '固';
                        break;
                    case 0x8CC6:
                        *str++ = '姑';
                        break;
                    case 0x8CC7:
                        *str++ = '孤';
                        break;
                    case 0x8CC8:
                        *str++ = '己';
                        break;
                    case 0x8CC9:
                        *str++ = '庫';
                        break;
                    case 0x8CCA:
                        *str++ = '弧';
                        break;
                    case 0x8CCB:
                        *str++ = '戸';
                        break;
                    case 0x8CCC:
                        *str++ = '故';
                        break;
                    case 0x8CCD:
                        *str++ = '枯';
                        break;
                    case 0x8CCE:
                        *str++ = '湖';
                        break;
                    case 0x8CCF:
                        *str++ = '狐';
                        break;
                    case 0x8CD0:
                        *str++ = '糊';
                        break;
                    case 0x8CD1:
                        *str++ = '袴';
                        break;
                    case 0x8CD2:
                        *str++ = '股';
                        break;
                    case 0x8CD3:
                        *str++ = '胡';
                        break;
                    case 0x8CD4:
                        *str++ = '菰';
                        break;
                    case 0x8CD5:
                        *str++ = '虎';
                        break;
                    case 0x8CD6:
                        *str++ = '誇';
                        break;
                    case 0x8CD7:
                        *str++ = '跨';
                        break;
                    case 0x8CD8:
                        *str++ = '鈷';
                        break;
                    case 0x8CD9:
                        *str++ = '雇';
                        break;
                    case 0x8CDA:
                        *str++ = '顧';
                        break;
                    case 0x8CDB:
                        *str++ = '鼓';
                        break;
                    case 0x8CDC:
                        *str++ = '五';
                        break;
                    case 0x8CDD:
                        *str++ = '互';
                        break;
                    case 0x8CDE:
                        *str++ = '伍';
                        break;
                    case 0x8CDF:
                        *str++ = '午';
                        break;
                    case 0x8CE0:
                        *str++ = '呉';
                        break;
                    case 0x8CE1:
                        *str++ = '吾';
                        break;
                    case 0x8CE2:
                        *str++ = '娯';
                        break;
                    case 0x8CE3:
                        *str++ = '後';
                        break;
                    case 0x8CE4:
                        *str++ = '御';
                        break;
                    case 0x8CE5:
                        *str++ = '悟';
                        break;
                    case 0x8CE6:
                        *str++ = '梧';
                        break;
                    case 0x8CE7:
                        *str++ = '檎';
                        break;
                    case 0x8CE8:
                        *str++ = '瑚';
                        break;
                    case 0x8CE9:
                        *str++ = '碁';
                        break;
                    case 0x8CEA:
                        *str++ = '語';
                        break;
                    case 0x8CEB:
                        *str++ = '誤';
                        break;
                    case 0x8CEC:
                        *str++ = '護';
                        break;
                    case 0x8CED:
                        *str++ = '醐';
                        break;
                    case 0x8CEE:
                        *str++ = '乞';
                        break;
                    case 0x8CEF:
                        *str++ = '鯉';
                        break;
                    case 0x8CF0:
                        *str++ = '交';
                        break;
                    case 0x8CF1:
                        *str++ = '佼';
                        break;
                    case 0x8CF2:
                        *str++ = '侯';
                        break;
                    case 0x8CF3:
                        *str++ = '候';
                        break;
                    case 0x8CF4:
                        *str++ = '倖';
                        break;
                    case 0x8CF5:
                        *str++ = '光';
                        break;
                    case 0x8CF6:
                        *str++ = '公';
                        break;
                    case 0x8CF7:
                        *str++ = '功';
                        break;
                    case 0x8CF8:
                        *str++ = '効';
                        break;
                    case 0x8CF9:
                        *str++ = '勾';
                        break;
                    case 0x8CFA:
                        *str++ = '厚';
                        break;
                    case 0x8CFB:
                        *str++ = '口';
                        break;
                    case 0x8CFC:
                        *str++ = '向';
                        break;
                    case 0x8D40:
                        *str++ = '后';
                        break;
                    case 0x8D41:
                        *str++ = '喉';
                        break;
                    case 0x8D42:
                        *str++ = '坑';
                        break;
                    case 0x8D43:
                        *str++ = '垢';
                        break;
                    case 0x8D44:
                        *str++ = '好';
                        break;
                    case 0x8D45:
                        *str++ = '孔';
                        break;
                    case 0x8D46:
                        *str++ = '孝';
                        break;
                    case 0x8D47:
                        *str++ = '宏';
                        break;
                    case 0x8D48:
                        *str++ = '工';
                        break;
                    case 0x8D49:
                        *str++ = '巧';
                        break;
                    case 0x8D4A:
                        *str++ = '巷';
                        break;
                    case 0x8D4B:
                        *str++ = '幸';
                        break;
                    case 0x8D4C:
                        *str++ = '広';
                        break;
                    case 0x8D4D:
                        *str++ = '庚';
                        break;
                    case 0x8D4E:
                        *str++ = '康';
                        break;
                    case 0x8D4F:
                        *str++ = '弘';
                        break;
                    case 0x8D50:
                        *str++ = '恒';
                        break;
                    case 0x8D51:
                        *str++ = '慌';
                        break;
                    case 0x8D52:
                        *str++ = '抗';
                        break;
                    case 0x8D53:
                        *str++ = '拘';
                        break;
                    case 0x8D54:
                        *str++ = '控';
                        break;
                    case 0x8D55:
                        *str++ = '攻';
                        break;
                    case 0x8D56:
                        *str++ = '昂';
                        break;
                    case 0x8D57:
                        *str++ = '晃';
                        break;
                    case 0x8D58:
                        *str++ = '更';
                        break;
                    case 0x8D59:
                        *str++ = '杭';
                        break;
                    case 0x8D5A:
                        *str++ = '校';
                        break;
                    case 0x8D5B:
                        *str++ = '梗';
                        break;
                    case 0x8D5C:
                        *str++ = '構';
                        break;
                    case 0x8D5D:
                        *str++ = '江';
                        break;
                    case 0x8D5E:
                        *str++ = '洪';
                        break;
                    case 0x8D5F:
                        *str++ = '浩';
                        break;
                    case 0x8D60:
                        *str++ = '港';
                        break;
                    case 0x8D61:
                        *str++ = '溝';
                        break;
                    case 0x8D62:
                        *str++ = '甲';
                        break;
                    case 0x8D63:
                        *str++ = '皇';
                        break;
                    case 0x8D64:
                        *str++ = '硬';
                        break;
                    case 0x8D65:
                        *str++ = '稿';
                        break;
                    case 0x8D66:
                        *str++ = '糠';
                        break;
                    case 0x8D67:
                        *str++ = '紅';
                        break;
                    case 0x8D68:
                        *str++ = '紘';
                        break;
                    case 0x8D69:
                        *str++ = '絞';
                        break;
                    case 0x8D6A:
                        *str++ = '綱';
                        break;
                    case 0x8D6B:
                        *str++ = '耕';
                        break;
                    case 0x8D6C:
                        *str++ = '考';
                        break;
                    case 0x8D6D:
                        *str++ = '肯';
                        break;
                    case 0x8D6E:
                        *str++ = '肱';
                        break;
                    case 0x8D6F:
                        *str++ = '腔';
                        break;
                    case 0x8D70:
                        *str++ = '膏';
                        break;
                    case 0x8D71:
                        *str++ = '航';
                        break;
                    case 0x8D72:
                        *str++ = '荒';
                        break;
                    case 0x8D73:
                        *str++ = '行';
                        break;
                    case 0x8D74:
                        *str++ = '衡';
                        break;
                    case 0x8D75:
                        *str++ = '講';
                        break;
                    case 0x8D76:
                        *str++ = '貢';
                        break;
                    case 0x8D77:
                        *str++ = '購';
                        break;
                    case 0x8D78:
                        *str++ = '郊';
                        break;
                    case 0x8D79:
                        *str++ = '酵';
                        break;
                    case 0x8D7A:
                        *str++ = '鉱';
                        break;
                    case 0x8D7B:
                        *str++ = '砿';
                        break;
                    case 0x8D7C:
                        *str++ = '鋼';
                        break;
                    case 0x8D7D:
                        *str++ = '閤';
                        break;
                    case 0x8D7E:
                        *str++ = '降';
                        break;
                    case 0x8D80:
                        *str++ = '項';
                        break;
                    case 0x8D81:
                        *str++ = '香';
                        break;
                    case 0x8D82:
                        *str++ = '高';
                        break;
                    case 0x8D83:
                        *str++ = '鴻';
                        break;
                    case 0x8D84:
                        *str++ = '剛';
                        break;
                    case 0x8D85:
                        *str++ = '劫';
                        break;
                    case 0x8D86:
                        *str++ = '号';
                        break;
                    case 0x8D87:
                        *str++ = '合';
                        break;
                    case 0x8D88:
                        *str++ = '壕';
                        break;
                    case 0x8D89:
                        *str++ = '拷';
                        break;
                    case 0x8D8A:
                        *str++ = '濠';
                        break;
                    case 0x8D8B:
                        *str++ = '豪';
                        break;
                    case 0x8D8C:
                        *str++ = '轟';
                        break;
                    case 0x8D8D:
                        *str++ = '麹';
                        break;
                    case 0x8D8E:
                        *str++ = '克';
                        break;
                    case 0x8D8F:
                        *str++ = '刻';
                        break;
                    case 0x8D90:
                        *str++ = '告';
                        break;
                    case 0x8D91:
                        *str++ = '国';
                        break;
                    case 0x8D92:
                        *str++ = '穀';
                        break;
                    case 0x8D93:
                        *str++ = '酷';
                        break;
                    case 0x8D94:
                        *str++ = '鵠';
                        break;
                    case 0x8D95:
                        *str++ = '黒';
                        break;
                    case 0x8D96:
                        *str++ = '獄';
                        break;
                    case 0x8D97:
                        *str++ = '漉';
                        break;
                    case 0x8D98:
                        *str++ = '腰';
                        break;
                    case 0x8D99:
                        *str++ = '甑';
                        break;
                    case 0x8D9A:
                        *str++ = '忽';
                        break;
                    case 0x8D9B:
                        *str++ = '惚';
                        break;
                    case 0x8D9C:
                        *str++ = '骨';
                        break;
                    case 0x8D9D:
                        *str++ = '狛';
                        break;
                    case 0x8D9E:
                        *str++ = '込';
                        break;
                    case 0x8D9F:
                        *str++ = '此';
                        break;
                    case 0x8DA0:
                        *str++ = '頃';
                        break;
                    case 0x8DA1:
                        *str++ = '今';
                        break;
                    case 0x8DA2:
                        *str++ = '困';
                        break;
                    case 0x8DA3:
                        *str++ = '坤';
                        break;
                    case 0x8DA4:
                        *str++ = '墾';
                        break;
                    case 0x8DA5:
                        *str++ = '婚';
                        break;
                    case 0x8DA6:
                        *str++ = '恨';
                        break;
                    case 0x8DA7:
                        *str++ = '懇';
                        break;
                    case 0x8DA8:
                        *str++ = '昏';
                        break;
                    case 0x8DA9:
                        *str++ = '昆';
                        break;
                    case 0x8DAA:
                        *str++ = '根';
                        break;
                    case 0x8DAB:
                        *str++ = '梱';
                        break;
                    case 0x8DAC:
                        *str++ = '混';
                        break;
                    case 0x8DAD:
                        *str++ = '痕';
                        break;
                    case 0x8DAE:
                        *str++ = '紺';
                        break;
                    case 0x8DAF:
                        *str++ = '艮';
                        break;
                    case 0x8DB0:
                        *str++ = '魂';
                        break;
                    case 0x8DB1:
                        *str++ = '些';
                        break;
                    case 0x8DB2:
                        *str++ = '佐';
                        break;
                    case 0x8DB3:
                        *str++ = '叉';
                        break;
                    case 0x8DB4:
                        *str++ = '唆';
                        break;
                    case 0x8DB5:
                        *str++ = '嵯';
                        break;
                    case 0x8DB6:
                        *str++ = '左';
                        break;
                    case 0x8DB7:
                        *str++ = '差';
                        break;
                    case 0x8DB8:
                        *str++ = '査';
                        break;
                    case 0x8DB9:
                        *str++ = '沙';
                        break;
                    case 0x8DBA:
                        *str++ = '瑳';
                        break;
                    case 0x8DBB:
                        *str++ = '砂';
                        break;
                    case 0x8DBC:
                        *str++ = '詐';
                        break;
                    case 0x8DBD:
                        *str++ = '鎖';
                        break;
                    case 0x8DBE:
                        *str++ = '裟';
                        break;
                    case 0x8DBF:
                        *str++ = '坐';
                        break;
                    case 0x8DC0:
                        *str++ = '座';
                        break;
                    case 0x8DC1:
                        *str++ = '挫';
                        break;
                    case 0x8DC2:
                        *str++ = '債';
                        break;
                    case 0x8DC3:
                        *str++ = '催';
                        break;
                    case 0x8DC4:
                        *str++ = '再';
                        break;
                    case 0x8DC5:
                        *str++ = '最';
                        break;
                    case 0x8DC6:
                        *str++ = '哉';
                        break;
                    case 0x8DC7:
                        *str++ = '塞';
                        break;
                    case 0x8DC8:
                        *str++ = '妻';
                        break;
                    case 0x8DC9:
                        *str++ = '宰';
                        break;
                    case 0x8DCA:
                        *str++ = '彩';
                        break;
                    case 0x8DCB:
                        *str++ = '才';
                        break;
                    case 0x8DCC:
                        *str++ = '採';
                        break;
                    case 0x8DCD:
                        *str++ = '栽';
                        break;
                    case 0x8DCE:
                        *str++ = '歳';
                        break;
                    case 0x8DCF:
                        *str++ = '済';
                        break;
                    case 0x8DD0:
                        *str++ = '災';
                        break;
                    case 0x8DD1:
                        *str++ = '采';
                        break;
                    case 0x8DD2:
                        *str++ = '犀';
                        break;
                    case 0x8DD3:
                        *str++ = '砕';
                        break;
                    case 0x8DD4:
                        *str++ = '砦';
                        break;
                    case 0x8DD5:
                        *str++ = '祭';
                        break;
                    case 0x8DD6:
                        *str++ = '斎';
                        break;
                    case 0x8DD7:
                        *str++ = '細';
                        break;
                    case 0x8DD8:
                        *str++ = '菜';
                        break;
                    case 0x8DD9:
                        *str++ = '裁';
                        break;
                    case 0x8DDA:
                        *str++ = '載';
                        break;
                    case 0x8DDB:
                        *str++ = '際';
                        break;
                    case 0x8DDC:
                        *str++ = '剤';
                        break;
                    case 0x8DDD:
                        *str++ = '在';
                        break;
                    case 0x8DDE:
                        *str++ = '材';
                        break;
                    case 0x8DDF:
                        *str++ = '罪';
                        break;
                    case 0x8DE0:
                        *str++ = '財';
                        break;
                    case 0x8DE1:
                        *str++ = '冴';
                        break;
                    case 0x8DE2:
                        *str++ = '坂';
                        break;
                    case 0x8DE3:
                        *str++ = '阪';
                        break;
                    case 0x8DE4:
                        *str++ = '堺';
                        break;
                    case 0x8DE5:
                        *str++ = '榊';
                        break;
                    case 0x8DE6:
                        *str++ = '肴';
                        break;
                    case 0x8DE7:
                        *str++ = '咲';
                        break;
                    case 0x8DE8:
                        *str++ = '崎';
                        break;
                    case 0x8DE9:
                        *str++ = '埼';
                        break;
                    case 0x8DEA:
                        *str++ = '碕';
                        break;
                    case 0x8DEB:
                        *str++ = '鷺';
                        break;
                    case 0x8DEC:
                        *str++ = '作';
                        break;
                    case 0x8DED:
                        *str++ = '削';
                        break;
                    case 0x8DEE:
                        *str++ = '咋';
                        break;
                    case 0x8DEF:
                        *str++ = '搾';
                        break;
                    case 0x8DF0:
                        *str++ = '昨';
                        break;
                    case 0x8DF1:
                        *str++ = '朔';
                        break;
                    case 0x8DF2:
                        *str++ = '柵';
                        break;
                    case 0x8DF3:
                        *str++ = '窄';
                        break;
                    case 0x8DF4:
                        *str++ = '策';
                        break;
                    case 0x8DF5:
                        *str++ = '索';
                        break;
                    case 0x8DF6:
                        *str++ = '錯';
                        break;
                    case 0x8DF7:
                        *str++ = '桜';
                        break;
                    case 0x8DF8:
                        *str++ = '鮭';
                        break;
                    case 0x8DF9:
                        *str++ = '笹';
                        break;
                    case 0x8DFA:
                        *str++ = '匙';
                        break;
                    case 0x8DFB:
                        *str++ = '冊';
                        break;
                    case 0x8DFC:
                        *str++ = '刷';
                        break;
                    case 0x8E40:
                        *str++ = '察';
                        break;
                    case 0x8E41:
                        *str++ = '拶';
                        break;
                    case 0x8E42:
                        *str++ = '撮';
                        break;
                    case 0x8E43:
                        *str++ = '擦';
                        break;
                    case 0x8E44:
                        *str++ = '札';
                        break;
                    case 0x8E45:
                        *str++ = '殺';
                        break;
                    case 0x8E46:
                        *str++ = '薩';
                        break;
                    case 0x8E47:
                        *str++ = '雑';
                        break;
                    case 0x8E48:
                        *str++ = '皐';
                        break;
                    case 0x8E49:
                        *str++ = '鯖';
                        break;
                    case 0x8E4A:
                        *str++ = '捌';
                        break;
                    case 0x8E4B:
                        *str++ = '錆';
                        break;
                    case 0x8E4C:
                        *str++ = '鮫';
                        break;
                    case 0x8E4D:
                        *str++ = '皿';
                        break;
                    case 0x8E4E:
                        *str++ = '晒';
                        break;
                    case 0x8E4F:
                        *str++ = '三';
                        break;
                    case 0x8E50:
                        *str++ = '傘';
                        break;
                    case 0x8E51:
                        *str++ = '参';
                        break;
                    case 0x8E52:
                        *str++ = '山';
                        break;
                    case 0x8E53:
                        *str++ = '惨';
                        break;
                    case 0x8E54:
                        *str++ = '撒';
                        break;
                    case 0x8E55:
                        *str++ = '散';
                        break;
                    case 0x8E56:
                        *str++ = '桟';
                        break;
                    case 0x8E57:
                        *str++ = '燦';
                        break;
                    case 0x8E58:
                        *str++ = '珊';
                        break;
                    case 0x8E59:
                        *str++ = '産';
                        break;
                    case 0x8E5A:
                        *str++ = '算';
                        break;
                    case 0x8E5B:
                        *str++ = '纂';
                        break;
                    case 0x8E5C:
                        *str++ = '蚕';
                        break;
                    case 0x8E5D:
                        *str++ = '讃';
                        break;
                    case 0x8E5E:
                        *str++ = '賛';
                        break;
                    case 0x8E5F:
                        *str++ = '酸';
                        break;
                    case 0x8E60:
                        *str++ = '餐';
                        break;
                    case 0x8E61:
                        *str++ = '斬';
                        break;
                    case 0x8E62:
                        *str++ = '暫';
                        break;
                    case 0x8E63:
                        *str++ = '残';
                        break;
                    case 0x8E64:
                        *str++ = '仕';
                        break;
                    case 0x8E65:
                        *str++ = '仔';
                        break;
                    case 0x8E66:
                        *str++ = '伺';
                        break;
                    case 0x8E67:
                        *str++ = '使';
                        break;
                    case 0x8E68:
                        *str++ = '刺';
                        break;
                    case 0x8E69:
                        *str++ = '司';
                        break;
                    case 0x8E6A:
                        *str++ = '史';
                        break;
                    case 0x8E6B:
                        *str++ = '嗣';
                        break;
                    case 0x8E6C:
                        *str++ = '四';
                        break;
                    case 0x8E6D:
                        *str++ = '士';
                        break;
                    case 0x8E6E:
                        *str++ = '始';
                        break;
                    case 0x8E6F:
                        *str++ = '姉';
                        break;
                    case 0x8E70:
                        *str++ = '姿';
                        break;
                    case 0x8E71:
                        *str++ = '子';
                        break;
                    case 0x8E72:
                        *str++ = '屍';
                        break;
                    case 0x8E73:
                        *str++ = '市';
                        break;
                    case 0x8E74:
                        *str++ = '師';
                        break;
                    case 0x8E75:
                        *str++ = '志';
                        break;
                    case 0x8E76:
                        *str++ = '思';
                        break;
                    case 0x8E77:
                        *str++ = '指';
                        break;
                    case 0x8E78:
                        *str++ = '支';
                        break;
                    case 0x8E79:
                        *str++ = '孜';
                        break;
                    case 0x8E7A:
                        *str++ = '斯';
                        break;
                    case 0x8E7B:
                        *str++ = '施';
                        break;
                    case 0x8E7C:
                        *str++ = '旨';
                        break;
                    case 0x8E7D:
                        *str++ = '枝';
                        break;
                    case 0x8E7E:
                        *str++ = '止';
                        break;
                    case 0x8E80:
                        *str++ = '死';
                        break;
                    case 0x8E81:
                        *str++ = '氏';
                        break;
                    case 0x8E82:
                        *str++ = '獅';
                        break;
                    case 0x8E83:
                        *str++ = '祉';
                        break;
                    case 0x8E84:
                        *str++ = '私';
                        break;
                    case 0x8E85:
                        *str++ = '糸';
                        break;
                    case 0x8E86:
                        *str++ = '紙';
                        break;
                    case 0x8E87:
                        *str++ = '紫';
                        break;
                    case 0x8E88:
                        *str++ = '肢';
                        break;
                    case 0x8E89:
                        *str++ = '脂';
                        break;
                    case 0x8E8A:
                        *str++ = '至';
                        break;
                    case 0x8E8B:
                        *str++ = '視';
                        break;
                    case 0x8E8C:
                        *str++ = '詞';
                        break;
                    case 0x8E8D:
                        *str++ = '詩';
                        break;
                    case 0x8E8E:
                        *str++ = '試';
                        break;
                    case 0x8E8F:
                        *str++ = '誌';
                        break;
                    case 0x8E90:
                        *str++ = '諮';
                        break;
                    case 0x8E91:
                        *str++ = '資';
                        break;
                    case 0x8E92:
                        *str++ = '賜';
                        break;
                    case 0x8E93:
                        *str++ = '雌';
                        break;
                    case 0x8E94:
                        *str++ = '飼';
                        break;
                    case 0x8E95:
                        *str++ = '歯';
                        break;
                    case 0x8E96:
                        *str++ = '事';
                        break;
                    case 0x8E97:
                        *str++ = '似';
                        break;
                    case 0x8E98:
                        *str++ = '侍';
                        break;
                    case 0x8E99:
                        *str++ = '児';
                        break;
                    case 0x8E9A:
                        *str++ = '字';
                        break;
                    case 0x8E9B:
                        *str++ = '寺';
                        break;
                    case 0x8E9C:
                        *str++ = '慈';
                        break;
                    case 0x8E9D:
                        *str++ = '持';
                        break;
                    case 0x8E9E:
                        *str++ = '時';
                        break;
                    case 0x8E9F:
                        *str++ = '次';
                        break;
                    case 0x8EA0:
                        *str++ = '滋';
                        break;
                    case 0x8EA1:
                        *str++ = '治';
                        break;
                    case 0x8EA2:
                        *str++ = '爾';
                        break;
                    case 0x8EA3:
                        *str++ = '璽';
                        break;
                    case 0x8EA4:
                        *str++ = '痔';
                        break;
                    case 0x8EA5:
                        *str++ = '磁';
                        break;
                    case 0x8EA6:
                        *str++ = '示';
                        break;
                    case 0x8EA7:
                        *str++ = '而';
                        break;
                    case 0x8EA8:
                        *str++ = '耳';
                        break;
                    case 0x8EA9:
                        *str++ = '自';
                        break;
                    case 0x8EAA:
                        *str++ = '蒔';
                        break;
                    case 0x8EAB:
                        *str++ = '辞';
                        break;
                    case 0x8EAC:
                        *str++ = '汐';
                        break;
                    case 0x8EAD:
                        *str++ = '鹿';
                        break;
                    case 0x8EAE:
                        *str++ = '式';
                        break;
                    case 0x8EAF:
                        *str++ = '識';
                        break;
                    case 0x8EB0:
                        *str++ = '鴫';
                        break;
                    case 0x8EB1:
                        *str++ = '竺';
                        break;
                    case 0x8EB2:
                        *str++ = '軸';
                        break;
                    case 0x8EB3:
                        *str++ = '宍';
                        break;
                    case 0x8EB4:
                        *str++ = '雫';
                        break;
                    case 0x8EB5:
                        *str++ = '七';
                        break;
                    case 0x8EB6:
                        *str++ = '叱';
                        break;
                    case 0x8EB7:
                        *str++ = '執';
                        break;
                    case 0x8EB8:
                        *str++ = '失';
                        break;
                    case 0x8EB9:
                        *str++ = '嫉';
                        break;
                    case 0x8EBA:
                        *str++ = '室';
                        break;
                    case 0x8EBB:
                        *str++ = '悉';
                        break;
                    case 0x8EBC:
                        *str++ = '湿';
                        break;
                    case 0x8EBD:
                        *str++ = '漆';
                        break;
                    case 0x8EBE:
                        *str++ = '疾';
                        break;
                    case 0x8EBF:
                        *str++ = '質';
                        break;
                    case 0x8EC0:
                        *str++ = '実';
                        break;
                    case 0x8EC1:
                        *str++ = '蔀';
                        break;
                    case 0x8EC2:
                        *str++ = '篠';
                        break;
                    case 0x8EC3:
                        *str++ = '偲';
                        break;
                    case 0x8EC4:
                        *str++ = '柴';
                        break;
                    case 0x8EC5:
                        *str++ = '芝';
                        break;
                    case 0x8EC6:
                        *str++ = '屡';
                        break;
                    case 0x8EC7:
                        *str++ = '蕊';
                        break;
                    case 0x8EC8:
                        *str++ = '縞';
                        break;
                    case 0x8EC9:
                        *str++ = '舎';
                        break;
                    case 0x8ECA:
                        *str++ = '写';
                        break;
                    case 0x8ECB:
                        *str++ = '射';
                        break;
                    case 0x8ECC:
                        *str++ = '捨';
                        break;
                    case 0x8ECD:
                        *str++ = '赦';
                        break;
                    case 0x8ECE:
                        *str++ = '斜';
                        break;
                    case 0x8ECF:
                        *str++ = '煮';
                        break;
                    case 0x8ED0:
                        *str++ = '社';
                        break;
                    case 0x8ED1:
                        *str++ = '紗';
                        break;
                    case 0x8ED2:
                        *str++ = '者';
                        break;
                    case 0x8ED3:
                        *str++ = '謝';
                        break;
                    case 0x8ED4:
                        *str++ = '車';
                        break;
                    case 0x8ED5:
                        *str++ = '遮';
                        break;
                    case 0x8ED6:
                        *str++ = '蛇';
                        break;
                    case 0x8ED7:
                        *str++ = '邪';
                        break;
                    case 0x8ED8:
                        *str++ = '借';
                        break;
                    case 0x8ED9:
                        *str++ = '勺';
                        break;
                    case 0x8EDA:
                        *str++ = '尺';
                        break;
                    case 0x8EDB:
                        *str++ = '杓';
                        break;
                    case 0x8EDC:
                        *str++ = '灼';
                        break;
                    case 0x8EDD:
                        *str++ = '爵';
                        break;
                    case 0x8EDE:
                        *str++ = '酌';
                        break;
                    case 0x8EDF:
                        *str++ = '釈';
                        break;
                    case 0x8EE0:
                        *str++ = '錫';
                        break;
                    case 0x8EE1:
                        *str++ = '若';
                        break;
                    case 0x8EE2:
                        *str++ = '寂';
                        break;
                    case 0x8EE3:
                        *str++ = '弱';
                        break;
                    case 0x8EE4:
                        *str++ = '惹';
                        break;
                    case 0x8EE5:
                        *str++ = '主';
                        break;
                    case 0x8EE6:
                        *str++ = '取';
                        break;
                    case 0x8EE7:
                        *str++ = '守';
                        break;
                    case 0x8EE8:
                        *str++ = '手';
                        break;
                    case 0x8EE9:
                        *str++ = '朱';
                        break;
                    case 0x8EEA:
                        *str++ = '殊';
                        break;
                    case 0x8EEB:
                        *str++ = '狩';
                        break;
                    case 0x8EEC:
                        *str++ = '珠';
                        break;
                    case 0x8EED:
                        *str++ = '種';
                        break;
                    case 0x8EEE:
                        *str++ = '腫';
                        break;
                    case 0x8EEF:
                        *str++ = '趣';
                        break;
                    case 0x8EF0:
                        *str++ = '酒';
                        break;
                    case 0x8EF1:
                        *str++ = '首';
                        break;
                    case 0x8EF2:
                        *str++ = '儒';
                        break;
                    case 0x8EF3:
                        *str++ = '受';
                        break;
                    case 0x8EF4:
                        *str++ = '呪';
                        break;
                    case 0x8EF5:
                        *str++ = '寿';
                        break;
                    case 0x8EF6:
                        *str++ = '授';
                        break;
                    case 0x8EF7:
                        *str++ = '樹';
                        break;
                    case 0x8EF8:
                        *str++ = '綬';
                        break;
                    case 0x8EF9:
                        *str++ = '需';
                        break;
                    case 0x8EFA:
                        *str++ = '囚';
                        break;
                    case 0x8EFB:
                        *str++ = '収';
                        break;
                    case 0x8EFC:
                        *str++ = '周';
                        break;
                    case 0x8F40:
                        *str++ = '宗';
                        break;
                    case 0x8F41:
                        *str++ = '就';
                        break;
                    case 0x8F42:
                        *str++ = '州';
                        break;
                    case 0x8F43:
                        *str++ = '修';
                        break;
                    case 0x8F44:
                        *str++ = '愁';
                        break;
                    case 0x8F45:
                        *str++ = '拾';
                        break;
                    case 0x8F46:
                        *str++ = '洲';
                        break;
                    case 0x8F47:
                        *str++ = '秀';
                        break;
                    case 0x8F48:
                        *str++ = '秋';
                        break;
                    case 0x8F49:
                        *str++ = '終';
                        break;
                    case 0x8F4A:
                        *str++ = '繍';
                        break;
                    case 0x8F4B:
                        *str++ = '習';
                        break;
                    case 0x8F4C:
                        *str++ = '臭';
                        break;
                    case 0x8F4D:
                        *str++ = '舟';
                        break;
                    case 0x8F4E:
                        *str++ = '蒐';
                        break;
                    case 0x8F4F:
                        *str++ = '衆';
                        break;
                    case 0x8F50:
                        *str++ = '襲';
                        break;
                    case 0x8F51:
                        *str++ = '讐';
                        break;
                    case 0x8F52:
                        *str++ = '蹴';
                        break;
                    case 0x8F53:
                        *str++ = '輯';
                        break;
                    case 0x8F54:
                        *str++ = '週';
                        break;
                    case 0x8F55:
                        *str++ = '酋';
                        break;
                    case 0x8F56:
                        *str++ = '酬';
                        break;
                    case 0x8F57:
                        *str++ = '集';
                        break;
                    case 0x8F58:
                        *str++ = '醜';
                        break;
                    case 0x8F59:
                        *str++ = '什';
                        break;
                    case 0x8F5A:
                        *str++ = '住';
                        break;
                    case 0x8F5B:
                        *str++ = '充';
                        break;
                    case 0x8F5C:
                        *str++ = '十';
                        break;
                    case 0x8F5D:
                        *str++ = '従';
                        break;
                    case 0x8F5E:
                        *str++ = '戎';
                        break;
                    case 0x8F5F:
                        *str++ = '柔';
                        break;
                    case 0x8F60:
                        *str++ = '汁';
                        break;
                    case 0x8F61:
                        *str++ = '渋';
                        break;
                    case 0x8F62:
                        *str++ = '獣';
                        break;
                    case 0x8F63:
                        *str++ = '縦';
                        break;
                    case 0x8F64:
                        *str++ = '重';
                        break;
                    case 0x8F65:
                        *str++ = '銃';
                        break;
                    case 0x8F66:
                        *str++ = '叔';
                        break;
                    case 0x8F67:
                        *str++ = '夙';
                        break;
                    case 0x8F68:
                        *str++ = '宿';
                        break;
                    case 0x8F69:
                        *str++ = '淑';
                        break;
                    case 0x8F6A:
                        *str++ = '祝';
                        break;
                    case 0x8F6B:
                        *str++ = '縮';
                        break;
                    case 0x8F6C:
                        *str++ = '粛';
                        break;
                    case 0x8F6D:
                        *str++ = '塾';
                        break;
                    case 0x8F6E:
                        *str++ = '熟';
                        break;
                    case 0x8F6F:
                        *str++ = '出';
                        break;
                    case 0x8F70:
                        *str++ = '術';
                        break;
                    case 0x8F71:
                        *str++ = '述';
                        break;
                    case 0x8F72:
                        *str++ = '俊';
                        break;
                    case 0x8F73:
                        *str++ = '峻';
                        break;
                    case 0x8F74:
                        *str++ = '春';
                        break;
                    case 0x8F75:
                        *str++ = '瞬';
                        break;
                    case 0x8F76:
                        *str++ = '竣';
                        break;
                    case 0x8F77:
                        *str++ = '舜';
                        break;
                    case 0x8F78:
                        *str++ = '駿';
                        break;
                    case 0x8F79:
                        *str++ = '准';
                        break;
                    case 0x8F7A:
                        *str++ = '循';
                        break;
                    case 0x8F7B:
                        *str++ = '旬';
                        break;
                    case 0x8F7C:
                        *str++ = '楯';
                        break;
                    case 0x8F7D:
                        *str++ = '殉';
                        break;
                    case 0x8F7E:
                        *str++ = '淳';
                        break;
                    case 0x8F80:
                        *str++ = '準';
                        break;
                    case 0x8F81:
                        *str++ = '潤';
                        break;
                    case 0x8F82:
                        *str++ = '盾';
                        break;
                    case 0x8F83:
                        *str++ = '純';
                        break;
                    case 0x8F84:
                        *str++ = '巡';
                        break;
                    case 0x8F85:
                        *str++ = '遵';
                        break;
                    case 0x8F86:
                        *str++ = '醇';
                        break;
                    case 0x8F87:
                        *str++ = '順';
                        break;
                    case 0x8F88:
                        *str++ = '処';
                        break;
                    case 0x8F89:
                        *str++ = '初';
                        break;
                    case 0x8F8A:
                        *str++ = '所';
                        break;
                    case 0x8F8B:
                        *str++ = '暑';
                        break;
                    case 0x8F8C:
                        *str++ = '曙';
                        break;
                    case 0x8F8D:
                        *str++ = '渚';
                        break;
                    case 0x8F8E:
                        *str++ = '庶';
                        break;
                    case 0x8F8F:
                        *str++ = '緒';
                        break;
                    case 0x8F90:
                        *str++ = '署';
                        break;
                    case 0x8F91:
                        *str++ = '書';
                        break;
                    case 0x8F92:
                        *str++ = '薯';
                        break;
                    case 0x8F93:
                        *str++ = '藷';
                        break;
                    case 0x8F94:
                        *str++ = '諸';
                        break;
                    case 0x8F95:
                        *str++ = '助';
                        break;
                    case 0x8F96:
                        *str++ = '叙';
                        break;
                    case 0x8F97:
                        *str++ = '女';
                        break;
                    case 0x8F98:
                        *str++ = '序';
                        break;
                    case 0x8F99:
                        *str++ = '徐';
                        break;
                    case 0x8F9A:
                        *str++ = '恕';
                        break;
                    case 0x8F9B:
                        *str++ = '鋤';
                        break;
                    case 0x8F9C:
                        *str++ = '除';
                        break;
                    case 0x8F9D:
                        *str++ = '傷';
                        break;
                    case 0x8F9E:
                        *str++ = '償';
                        break;
                    case 0x8F9F:
                        *str++ = '勝';
                        break;
                    case 0x8FA0:
                        *str++ = '匠';
                        break;
                    case 0x8FA1:
                        *str++ = '升';
                        break;
                    case 0x8FA2:
                        *str++ = '召';
                        break;
                    case 0x8FA3:
                        *str++ = '哨';
                        break;
                    case 0x8FA4:
                        *str++ = '商';
                        break;
                    case 0x8FA5:
                        *str++ = '唱';
                        break;
                    case 0x8FA6:
                        *str++ = '嘗';
                        break;
                    case 0x8FA7:
                        *str++ = '奨';
                        break;
                    case 0x8FA8:
                        *str++ = '妾';
                        break;
                    case 0x8FA9:
                        *str++ = '娼';
                        break;
                    case 0x8FAA:
                        *str++ = '宵';
                        break;
                    case 0x8FAB:
                        *str++ = '将';
                        break;
                    case 0x8FAC:
                        *str++ = '小';
                        break;
                    case 0x8FAD:
                        *str++ = '少';
                        break;
                    case 0x8FAE:
                        *str++ = '尚';
                        break;
                    case 0x8FAF:
                        *str++ = '庄';
                        break;
                    case 0x8FB0:
                        *str++ = '床';
                        break;
                    case 0x8FB1:
                        *str++ = '廠';
                        break;
                    case 0x8FB2:
                        *str++ = '彰';
                        break;
                    case 0x8FB3:
                        *str++ = '承';
                        break;
                    case 0x8FB4:
                        *str++ = '抄';
                        break;
                    case 0x8FB5:
                        *str++ = '招';
                        break;
                    case 0x8FB6:
                        *str++ = '掌';
                        break;
                    case 0x8FB7:
                        *str++ = '捷';
                        break;
                    case 0x8FB8:
                        *str++ = '昇';
                        break;
                    case 0x8FB9:
                        *str++ = '昌';
                        break;
                    case 0x8FBA:
                        *str++ = '昭';
                        break;
                    case 0x8FBB:
                        *str++ = '晶';
                        break;
                    case 0x8FBC:
                        *str++ = '松';
                        break;
                    case 0x8FBD:
                        *str++ = '梢';
                        break;
                    case 0x8FBE:
                        *str++ = '樟';
                        break;
                    case 0x8FBF:
                        *str++ = '樵';
                        break;
                    case 0x8FC0:
                        *str++ = '沼';
                        break;
                    case 0x8FC1:
                        *str++ = '消';
                        break;
                    case 0x8FC2:
                        *str++ = '渉';
                        break;
                    case 0x8FC3:
                        *str++ = '湘';
                        break;
                    case 0x8FC4:
                        *str++ = '焼';
                        break;
                    case 0x8FC5:
                        *str++ = '焦';
                        break;
                    case 0x8FC6:
                        *str++ = '照';
                        break;
                    case 0x8FC7:
                        *str++ = '症';
                        break;
                    case 0x8FC8:
                        *str++ = '省';
                        break;
                    case 0x8FC9:
                        *str++ = '硝';
                        break;
                    case 0x8FCA:
                        *str++ = '礁';
                        break;
                    case 0x8FCB:
                        *str++ = '祥';
                        break;
                    case 0x8FCC:
                        *str++ = '称';
                        break;
                    case 0x8FCD:
                        *str++ = '章';
                        break;
                    case 0x8FCE:
                        *str++ = '笑';
                        break;
                    case 0x8FCF:
                        *str++ = '粧';
                        break;
                    case 0x8FD0:
                        *str++ = '紹';
                        break;
                    case 0x8FD1:
                        *str++ = '肖';
                        break;
                    case 0x8FD2:
                        *str++ = '菖';
                        break;
                    case 0x8FD3:
                        *str++ = '蒋';
                        break;
                    case 0x8FD4:
                        *str++ = '蕉';
                        break;
                    case 0x8FD5:
                        *str++ = '衝';
                        break;
                    case 0x8FD6:
                        *str++ = '裳';
                        break;
                    case 0x8FD7:
                        *str++ = '訟';
                        break;
                    case 0x8FD8:
                        *str++ = '証';
                        break;
                    case 0x8FD9:
                        *str++ = '詔';
                        break;
                    case 0x8FDA:
                        *str++ = '詳';
                        break;
                    case 0x8FDB:
                        *str++ = '象';
                        break;
                    case 0x8FDC:
                        *str++ = '賞';
                        break;
                    case 0x8FDD:
                        *str++ = '醤';
                        break;
                    case 0x8FDE:
                        *str++ = '鉦';
                        break;
                    case 0x8FDF:
                        *str++ = '鍾';
                        break;
                    case 0x8FE0:
                        *str++ = '鐘';
                        break;
                    case 0x8FE1:
                        *str++ = '障';
                        break;
                    case 0x8FE2:
                        *str++ = '鞘';
                        break;
                    case 0x8FE3:
                        *str++ = '上';
                        break;
                    case 0x8FE4:
                        *str++ = '丈';
                        break;
                    case 0x8FE5:
                        *str++ = '丞';
                        break;
                    case 0x8FE6:
                        *str++ = '乗';
                        break;
                    case 0x8FE7:
                        *str++ = '冗';
                        break;
                    case 0x8FE8:
                        *str++ = '剰';
                        break;
                    case 0x8FE9:
                        *str++ = '城';
                        break;
                    case 0x8FEA:
                        *str++ = '場';
                        break;
                    case 0x8FEB:
                        *str++ = '壌';
                        break;
                    case 0x8FEC:
                        *str++ = '嬢';
                        break;
                    case 0x8FED:
                        *str++ = '常';
                        break;
                    case 0x8FEE:
                        *str++ = '情';
                        break;
                    case 0x8FEF:
                        *str++ = '擾';
                        break;
                    case 0x8FF0:
                        *str++ = '条';
                        break;
                    case 0x8FF1:
                        *str++ = '杖';
                        break;
                    case 0x8FF2:
                        *str++ = '浄';
                        break;
                    case 0x8FF3:
                        *str++ = '状';
                        break;
                    case 0x8FF4:
                        *str++ = '畳';
                        break;
                    case 0x8FF5:
                        *str++ = '穣';
                        break;
                    case 0x8FF6:
                        *str++ = '蒸';
                        break;
                    case 0x8FF7:
                        *str++ = '譲';
                        break;
                    case 0x8FF8:
                        *str++ = '醸';
                        break;
                    case 0x8FF9:
                        *str++ = '錠';
                        break;
                    case 0x8FFA:
                        *str++ = '嘱';
                        break;
                    case 0x8FFB:
                        *str++ = '埴';
                        break;
                    case 0x8FFC:
                        *str++ = '飾';
                        break;
                    case 0x9040:
                        *str++ = '拭';
                        break;
                    case 0x9041:
                        *str++ = '植';
                        break;
                    case 0x9042:
                        *str++ = '殖';
                        break;
                    case 0x9043:
                        *str++ = '燭';
                        break;
                    case 0x9044:
                        *str++ = '織';
                        break;
                    case 0x9045:
                        *str++ = '職';
                        break;
                    case 0x9046:
                        *str++ = '色';
                        break;
                    case 0x9047:
                        *str++ = '触';
                        break;
                    case 0x9048:
                        *str++ = '食';
                        break;
                    case 0x9049:
                        *str++ = '蝕';
                        break;
                    case 0x904A:
                        *str++ = '辱';
                        break;
                    case 0x904B:
                        *str++ = '尻';
                        break;
                    case 0x904C:
                        *str++ = '伸';
                        break;
                    case 0x904D:
                        *str++ = '信';
                        break;
                    case 0x904E:
                        *str++ = '侵';
                        break;
                    case 0x904F:
                        *str++ = '唇';
                        break;
                    case 0x9050:
                        *str++ = '娠';
                        break;
                    case 0x9051:
                        *str++ = '寝';
                        break;
                    case 0x9052:
                        *str++ = '審';
                        break;
                    case 0x9053:
                        *str++ = '心';
                        break;
                    case 0x9054:
                        *str++ = '慎';
                        break;
                    case 0x9055:
                        *str++ = '振';
                        break;
                    case 0x9056:
                        *str++ = '新';
                        break;
                    case 0x9057:
                        *str++ = '晋';
                        break;
                    case 0x9058:
                        *str++ = '森';
                        break;
                    case 0x9059:
                        *str++ = '榛';
                        break;
                    case 0x905A:
                        *str++ = '浸';
                        break;
                    case 0x905B:
                        *str++ = '深';
                        break;
                    case 0x905C:
                        *str++ = '申';
                        break;
                    case 0x905D:
                        *str++ = '疹';
                        break;
                    case 0x905E:
                        *str++ = '真';
                        break;
                    case 0x905F:
                        *str++ = '神';
                        break;
                    case 0x9060:
                        *str++ = '秦';
                        break;
                    case 0x9061:
                        *str++ = '紳';
                        break;
                    case 0x9062:
                        *str++ = '臣';
                        break;
                    case 0x9063:
                        *str++ = '芯';
                        break;
                    case 0x9064:
                        *str++ = '薪';
                        break;
                    case 0x9065:
                        *str++ = '親';
                        break;
                    case 0x9066:
                        *str++ = '診';
                        break;
                    case 0x9067:
                        *str++ = '身';
                        break;
                    case 0x9068:
                        *str++ = '辛';
                        break;
                    case 0x9069:
                        *str++ = '進';
                        break;
                    case 0x906A:
                        *str++ = '針';
                        break;
                    case 0x906B:
                        *str++ = '震';
                        break;
                    case 0x906C:
                        *str++ = '人';
                        break;
                    case 0x906D:
                        *str++ = '仁';
                        break;
                    case 0x906E:
                        *str++ = '刃';
                        break;
                    case 0x906F:
                        *str++ = '塵';
                        break;
                    case 0x9070:
                        *str++ = '壬';
                        break;
                    case 0x9071:
                        *str++ = '尋';
                        break;
                    case 0x9072:
                        *str++ = '甚';
                        break;
                    case 0x9073:
                        *str++ = '尽';
                        break;
                    case 0x9074:
                        *str++ = '腎';
                        break;
                    case 0x9075:
                        *str++ = '訊';
                        break;
                    case 0x9076:
                        *str++ = '迅';
                        break;
                    case 0x9077:
                        *str++ = '陣';
                        break;
                    case 0x9078:
                        *str++ = '靭';
                        break;
                    case 0x9079:
                        *str++ = '笥';
                        break;
                    case 0x907A:
                        *str++ = '諏';
                        break;
                    case 0x907B:
                        *str++ = '須';
                        break;
                    case 0x907C:
                        *str++ = '酢';
                        break;
                    case 0x907D:
                        *str++ = '図';
                        break;
                    case 0x907E:
                        *str++ = '厨';
                        break;
                    case 0x9080:
                        *str++ = '逗';
                        break;
                    case 0x9081:
                        *str++ = '吹';
                        break;
                    case 0x9082:
                        *str++ = '垂';
                        break;
                    case 0x9083:
                        *str++ = '帥';
                        break;
                    case 0x9084:
                        *str++ = '推';
                        break;
                    case 0x9085:
                        *str++ = '水';
                        break;
                    case 0x9086:
                        *str++ = '炊';
                        break;
                    case 0x9087:
                        *str++ = '睡';
                        break;
                    case 0x9088:
                        *str++ = '粋';
                        break;
                    case 0x9089:
                        *str++ = '翠';
                        break;
                    case 0x908A:
                        *str++ = '衰';
                        break;
                    case 0x908B:
                        *str++ = '遂';
                        break;
                    case 0x908C:
                        *str++ = '酔';
                        break;
                    case 0x908D:
                        *str++ = '錐';
                        break;
                    case 0x908E:
                        *str++ = '錘';
                        break;
                    case 0x908F:
                        *str++ = '随';
                        break;
                    case 0x9090:
                        *str++ = '瑞';
                        break;
                    case 0x9091:
                        *str++ = '髄';
                        break;
                    case 0x9092:
                        *str++ = '崇';
                        break;
                    case 0x9093:
                        *str++ = '嵩';
                        break;
                    case 0x9094:
                        *str++ = '数';
                        break;
                    case 0x9095:
                        *str++ = '枢';
                        break;
                    case 0x9096:
                        *str++ = '趨';
                        break;
                    case 0x9097:
                        *str++ = '雛';
                        break;
                    case 0x9098:
                        *str++ = '据';
                        break;
                    case 0x9099:
                        *str++ = '杉';
                        break;
                    case 0x909A:
                        *str++ = '椙';
                        break;
                    case 0x909B:
                        *str++ = '菅';
                        break;
                    case 0x909C:
                        *str++ = '頗';
                        break;
                    case 0x909D:
                        *str++ = '雀';
                        break;
                    case 0x909E:
                        *str++ = '裾';
                        break;
                    case 0x909F:
                        *str++ = '澄';
                        break;
                    case 0x90A0:
                        *str++ = '摺';
                        break;
                    case 0x90A1:
                        *str++ = '寸';
                        break;
                    case 0x90A2:
                        *str++ = '世';
                        break;
                    case 0x90A3:
                        *str++ = '瀬';
                        break;
                    case 0x90A4:
                        *str++ = '畝';
                        break;
                    case 0x90A5:
                        *str++ = '是';
                        break;
                    case 0x90A6:
                        *str++ = '凄';
                        break;
                    case 0x90A7:
                        *str++ = '制';
                        break;
                    case 0x90A8:
                        *str++ = '勢';
                        break;
                    case 0x90A9:
                        *str++ = '姓';
                        break;
                    case 0x90AA:
                        *str++ = '征';
                        break;
                    case 0x90AB:
                        *str++ = '性';
                        break;
                    case 0x90AC:
                        *str++ = '成';
                        break;
                    case 0x90AD:
                        *str++ = '政';
                        break;
                    case 0x90AE:
                        *str++ = '整';
                        break;
                    case 0x90AF:
                        *str++ = '星';
                        break;
                    case 0x90B0:
                        *str++ = '晴';
                        break;
                    case 0x90B1:
                        *str++ = '棲';
                        break;
                    case 0x90B2:
                        *str++ = '栖';
                        break;
                    case 0x90B3:
                        *str++ = '正';
                        break;
                    case 0x90B4:
                        *str++ = '清';
                        break;
                    case 0x90B5:
                        *str++ = '牲';
                        break;
                    case 0x90B6:
                        *str++ = '生';
                        break;
                    case 0x90B7:
                        *str++ = '盛';
                        break;
                    case 0x90B8:
                        *str++ = '精';
                        break;
                    case 0x90B9:
                        *str++ = '聖';
                        break;
                    case 0x90BA:
                        *str++ = '声';
                        break;
                    case 0x90BB:
                        *str++ = '製';
                        break;
                    case 0x90BC:
                        *str++ = '西';
                        break;
                    case 0x90BD:
                        *str++ = '誠';
                        break;
                    case 0x90BE:
                        *str++ = '誓';
                        break;
                    case 0x90BF:
                        *str++ = '請';
                        break;
                    case 0x90C0:
                        *str++ = '逝';
                        break;
                    case 0x90C1:
                        *str++ = '醒';
                        break;
                    case 0x90C2:
                        *str++ = '青';
                        break;
                    case 0x90C3:
                        *str++ = '静';
                        break;
                    case 0x90C4:
                        *str++ = '斉';
                        break;
                    case 0x90C5:
                        *str++ = '税';
                        break;
                    case 0x90C6:
                        *str++ = '脆';
                        break;
                    case 0x90C7:
                        *str++ = '隻';
                        break;
                    case 0x90C8:
                        *str++ = '席';
                        break;
                    case 0x90C9:
                        *str++ = '惜';
                        break;
                    case 0x90CA:
                        *str++ = '戚';
                        break;
                    case 0x90CB:
                        *str++ = '斥';
                        break;
                    case 0x90CC:
                        *str++ = '昔';
                        break;
                    case 0x90CD:
                        *str++ = '析';
                        break;
                    case 0x90CE:
                        *str++ = '石';
                        break;
                    case 0x90CF:
                        *str++ = '積';
                        break;
                    case 0x90D0:
                        *str++ = '籍';
                        break;
                    case 0x90D1:
                        *str++ = '績';
                        break;
                    case 0x90D2:
                        *str++ = '脊';
                        break;
                    case 0x90D3:
                        *str++ = '責';
                        break;
                    case 0x90D4:
                        *str++ = '赤';
                        break;
                    case 0x90D5:
                        *str++ = '跡';
                        break;
                    case 0x90D6:
                        *str++ = '蹟';
                        break;
                    case 0x90D7:
                        *str++ = '碩';
                        break;
                    case 0x90D8:
                        *str++ = '切';
                        break;
                    case 0x90D9:
                        *str++ = '拙';
                        break;
                    case 0x90DA:
                        *str++ = '接';
                        break;
                    case 0x90DB:
                        *str++ = '摂';
                        break;
                    case 0x90DC:
                        *str++ = '折';
                        break;
                    case 0x90DD:
                        *str++ = '設';
                        break;
                    case 0x90DE:
                        *str++ = '窃';
                        break;
                    case 0x90DF:
                        *str++ = '節';
                        break;
                    case 0x90E0:
                        *str++ = '説';
                        break;
                    case 0x90E1:
                        *str++ = '雪';
                        break;
                    case 0x90E2:
                        *str++ = '絶';
                        break;
                    case 0x90E3:
                        *str++ = '舌';
                        break;
                    case 0x90E4:
                        *str++ = '蝉';
                        break;
                    case 0x90E5:
                        *str++ = '仙';
                        break;
                    case 0x90E6:
                        *str++ = '先';
                        break;
                    case 0x90E7:
                        *str++ = '千';
                        break;
                    case 0x90E8:
                        *str++ = '占';
                        break;
                    case 0x90E9:
                        *str++ = '宣';
                        break;
                    case 0x90EA:
                        *str++ = '専';
                        break;
                    case 0x90EB:
                        *str++ = '尖';
                        break;
                    case 0x90EC:
                        *str++ = '川';
                        break;
                    case 0x90ED:
                        *str++ = '戦';
                        break;
                    case 0x90EE:
                        *str++ = '扇';
                        break;
                    case 0x90EF:
                        *str++ = '撰';
                        break;
                    case 0x90F0:
                        *str++ = '栓';
                        break;
                    case 0x90F1:
                        *str++ = '栴';
                        break;
                    case 0x90F2:
                        *str++ = '泉';
                        break;
                    case 0x90F3:
                        *str++ = '浅';
                        break;
                    case 0x90F4:
                        *str++ = '洗';
                        break;
                    case 0x90F5:
                        *str++ = '染';
                        break;
                    case 0x90F6:
                        *str++ = '潜';
                        break;
                    case 0x90F7:
                        *str++ = '煎';
                        break;
                    case 0x90F8:
                        *str++ = '煽';
                        break;
                    case 0x90F9:
                        *str++ = '旋';
                        break;
                    case 0x90FA:
                        *str++ = '穿';
                        break;
                    case 0x90FB:
                        *str++ = '箭';
                        break;
                    case 0x90FC:
                        *str++ = '線';
                        break;
                    case 0x9140:
                        *str++ = '繊';
                        break;
                    case 0x9141:
                        *str++ = '羨';
                        break;
                    case 0x9142:
                        *str++ = '腺';
                        break;
                    case 0x9143:
                        *str++ = '舛';
                        break;
                    case 0x9144:
                        *str++ = '船';
                        break;
                    case 0x9145:
                        *str++ = '薦';
                        break;
                    case 0x9146:
                        *str++ = '詮';
                        break;
                    case 0x9147:
                        *str++ = '賎';
                        break;
                    case 0x9148:
                        *str++ = '践';
                        break;
                    case 0x9149:
                        *str++ = '選';
                        break;
                    case 0x914A:
                        *str++ = '遷';
                        break;
                    case 0x914B:
                        *str++ = '銭';
                        break;
                    case 0x914C:
                        *str++ = '銑';
                        break;
                    case 0x914D:
                        *str++ = '閃';
                        break;
                    case 0x914E:
                        *str++ = '鮮';
                        break;
                    case 0x914F:
                        *str++ = '前';
                        break;
                    case 0x9150:
                        *str++ = '善';
                        break;
                    case 0x9151:
                        *str++ = '漸';
                        break;
                    case 0x9152:
                        *str++ = '然';
                        break;
                    case 0x9153:
                        *str++ = '全';
                        break;
                    case 0x9154:
                        *str++ = '禅';
                        break;
                    case 0x9155:
                        *str++ = '繕';
                        break;
                    case 0x9156:
                        *str++ = '膳';
                        break;
                    case 0x9157:
                        *str++ = '糎';
                        break;
                    case 0x9158:
                        *str++ = '噌';
                        break;
                    case 0x9159:
                        *str++ = '塑';
                        break;
                    case 0x915A:
                        *str++ = '岨';
                        break;
                    case 0x915B:
                        *str++ = '措';
                        break;
                    case 0x915C:
                        *str++ = '曾';
                        break;
                    case 0x915D:
                        *str++ = '曽';
                        break;
                    case 0x915E:
                        *str++ = '楚';
                        break;
                    case 0x915F:
                        *str++ = '狙';
                        break;
                    case 0x9160:
                        *str++ = '疏';
                        break;
                    case 0x9161:
                        *str++ = '疎';
                        break;
                    case 0x9162:
                        *str++ = '礎';
                        break;
                    case 0x9163:
                        *str++ = '祖';
                        break;
                    case 0x9164:
                        *str++ = '租';
                        break;
                    case 0x9165:
                        *str++ = '粗';
                        break;
                    case 0x9166:
                        *str++ = '素';
                        break;
                    case 0x9167:
                        *str++ = '組';
                        break;
                    case 0x9168:
                        *str++ = '蘇';
                        break;
                    case 0x9169:
                        *str++ = '訴';
                        break;
                    case 0x916A:
                        *str++ = '阻';
                        break;
                    case 0x916B:
                        *str++ = '遡';
                        break;
                    case 0x916C:
                        *str++ = '鼠';
                        break;
                    case 0x916D:
                        *str++ = '僧';
                        break;
                    case 0x916E:
                        *str++ = '創';
                        break;
                    case 0x916F:
                        *str++ = '双';
                        break;
                    case 0x9170:
                        *str++ = '叢';
                        break;
                    case 0x9171:
                        *str++ = '倉';
                        break;
                    case 0x9172:
                        *str++ = '喪';
                        break;
                    case 0x9173:
                        *str++ = '壮';
                        break;
                    case 0x9174:
                        *str++ = '奏';
                        break;
                    case 0x9175:
                        *str++ = '爽';
                        break;
                    case 0x9176:
                        *str++ = '宋';
                        break;
                    case 0x9177:
                        *str++ = '層';
                        break;
                    case 0x9178:
                        *str++ = '匝';
                        break;
                    case 0x9179:
                        *str++ = '惣';
                        break;
                    case 0x917A:
                        *str++ = '想';
                        break;
                    case 0x917B:
                        *str++ = '捜';
                        break;
                    case 0x917C:
                        *str++ = '掃';
                        break;
                    case 0x917D:
                        *str++ = '挿';
                        break;
                    case 0x917E:
                        *str++ = '掻';
                        break;
                    case 0x9180:
                        *str++ = '操';
                        break;
                    case 0x9181:
                        *str++ = '早';
                        break;
                    case 0x9182:
                        *str++ = '曹';
                        break;
                    case 0x9183:
                        *str++ = '巣';
                        break;
                    case 0x9184:
                        *str++ = '槍';
                        break;
                    case 0x9185:
                        *str++ = '槽';
                        break;
                    case 0x9186:
                        *str++ = '漕';
                        break;
                    case 0x9187:
                        *str++ = '燥';
                        break;
                    case 0x9188:
                        *str++ = '争';
                        break;
                    case 0x9189:
                        *str++ = '痩';
                        break;
                    case 0x918A:
                        *str++ = '相';
                        break;
                    case 0x918B:
                        *str++ = '窓';
                        break;
                    case 0x918C:
                        *str++ = '糟';
                        break;
                    case 0x918D:
                        *str++ = '総';
                        break;
                    case 0x918E:
                        *str++ = '綜';
                        break;
                    case 0x918F:
                        *str++ = '聡';
                        break;
                    case 0x9190:
                        *str++ = '草';
                        break;
                    case 0x9191:
                        *str++ = '荘';
                        break;
                    case 0x9192:
                        *str++ = '葬';
                        break;
                    case 0x9193:
                        *str++ = '蒼';
                        break;
                    case 0x9194:
                        *str++ = '藻';
                        break;
                    case 0x9195:
                        *str++ = '装';
                        break;
                    case 0x9196:
                        *str++ = '走';
                        break;
                    case 0x9197:
                        *str++ = '送';
                        break;
                    case 0x9198:
                        *str++ = '遭';
                        break;
                    case 0x9199:
                        *str++ = '鎗';
                        break;
                    case 0x919A:
                        *str++ = '霜';
                        break;
                    case 0x919B:
                        *str++ = '騒';
                        break;
                    case 0x919C:
                        *str++ = '像';
                        break;
                    case 0x919D:
                        *str++ = '増';
                        break;
                    case 0x919E:
                        *str++ = '憎';
                        break;
                    case 0x919F:
                        *str++ = '臓';
                        break;
                    case 0x91A0:
                        *str++ = '蔵';
                        break;
                    case 0x91A1:
                        *str++ = '贈';
                        break;
                    case 0x91A2:
                        *str++ = '造';
                        break;
                    case 0x91A3:
                        *str++ = '促';
                        break;
                    case 0x91A4:
                        *str++ = '側';
                        break;
                    case 0x91A5:
                        *str++ = '則';
                        break;
                    case 0x91A6:
                        *str++ = '即';
                        break;
                    case 0x91A7:
                        *str++ = '息';
                        break;
                    case 0x91A8:
                        *str++ = '捉';
                        break;
                    case 0x91A9:
                        *str++ = '束';
                        break;
                    case 0x91AA:
                        *str++ = '測';
                        break;
                    case 0x91AB:
                        *str++ = '足';
                        break;
                    case 0x91AC:
                        *str++ = '速';
                        break;
                    case 0x91AD:
                        *str++ = '俗';
                        break;
                    case 0x91AE:
                        *str++ = '属';
                        break;
                    case 0x91AF:
                        *str++ = '賊';
                        break;
                    case 0x91B0:
                        *str++ = '族';
                        break;
                    case 0x91B1:
                        *str++ = '続';
                        break;
                    case 0x91B2:
                        *str++ = '卒';
                        break;
                    case 0x91B3:
                        *str++ = '袖';
                        break;
                    case 0x91B4:
                        *str++ = '其';
                        break;
                    case 0x91B5:
                        *str++ = '揃';
                        break;
                    case 0x91B6:
                        *str++ = '存';
                        break;
                    case 0x91B7:
                        *str++ = '孫';
                        break;
                    case 0x91B8:
                        *str++ = '尊';
                        break;
                    case 0x91B9:
                        *str++ = '損';
                        break;
                    case 0x91BA:
                        *str++ = '村';
                        break;
                    case 0x91BB:
                        *str++ = '遜';
                        break;
                    case 0x91BC:
                        *str++ = '他';
                        break;
                    case 0x91BD:
                        *str++ = '多';
                        break;
                    case 0x91BE:
                        *str++ = '太';
                        break;
                    case 0x91BF:
                        *str++ = '汰';
                        break;
                    case 0x91C0:
                        *str++ = '詑';
                        break;
                    case 0x91C1:
                        *str++ = '唾';
                        break;
                    case 0x91C2:
                        *str++ = '堕';
                        break;
                    case 0x91C3:
                        *str++ = '妥';
                        break;
                    case 0x91C4:
                        *str++ = '惰';
                        break;
                    case 0x91C5:
                        *str++ = '打';
                        break;
                    case 0x91C6:
                        *str++ = '柁';
                        break;
                    case 0x91C7:
                        *str++ = '舵';
                        break;
                    case 0x91C8:
                        *str++ = '楕';
                        break;
                    case 0x91C9:
                        *str++ = '陀';
                        break;
                    case 0x91CA:
                        *str++ = '駄';
                        break;
                    case 0x91CB:
                        *str++ = '騨';
                        break;
                    case 0x91CC:
                        *str++ = '体';
                        break;
                    case 0x91CD:
                        *str++ = '堆';
                        break;
                    case 0x91CE:
                        *str++ = '対';
                        break;
                    case 0x91CF:
                        *str++ = '耐';
                        break;
                    case 0x91D0:
                        *str++ = '岱';
                        break;
                    case 0x91D1:
                        *str++ = '帯';
                        break;
                    case 0x91D2:
                        *str++ = '待';
                        break;
                    case 0x91D3:
                        *str++ = '怠';
                        break;
                    case 0x91D4:
                        *str++ = '態';
                        break;
                    case 0x91D5:
                        *str++ = '戴';
                        break;
                    case 0x91D6:
                        *str++ = '替';
                        break;
                    case 0x91D7:
                        *str++ = '泰';
                        break;
                    case 0x91D8:
                        *str++ = '滞';
                        break;
                    case 0x91D9:
                        *str++ = '胎';
                        break;
                    case 0x91DA:
                        *str++ = '腿';
                        break;
                    case 0x91DB:
                        *str++ = '苔';
                        break;
                    case 0x91DC:
                        *str++ = '袋';
                        break;
                    case 0x91DD:
                        *str++ = '貸';
                        break;
                    case 0x91DE:
                        *str++ = '退';
                        break;
                    case 0x91DF:
                        *str++ = '逮';
                        break;
                    case 0x91E0:
                        *str++ = '隊';
                        break;
                    case 0x91E1:
                        *str++ = '黛';
                        break;
                    case 0x91E2:
                        *str++ = '鯛';
                        break;
                    case 0x91E3:
                        *str++ = '代';
                        break;
                    case 0x91E4:
                        *str++ = '台';
                        break;
                    case 0x91E5:
                        *str++ = '大';
                        break;
                    case 0x91E6:
                        *str++ = '第';
                        break;
                    case 0x91E7:
                        *str++ = '醍';
                        break;
                    case 0x91E8:
                        *str++ = '題';
                        break;
                    case 0x91E9:
                        *str++ = '鷹';
                        break;
                    case 0x91EA:
                        *str++ = '滝';
                        break;
                    case 0x91EB:
                        *str++ = '瀧';
                        break;
                    case 0x91EC:
                        *str++ = '卓';
                        break;
                    case 0x91ED:
                        *str++ = '啄';
                        break;
                    case 0x91EE:
                        *str++ = '宅';
                        break;
                    case 0x91EF:
                        *str++ = '托';
                        break;
                    case 0x91F0:
                        *str++ = '択';
                        break;
                    case 0x91F1:
                        *str++ = '拓';
                        break;
                    case 0x91F2:
                        *str++ = '沢';
                        break;
                    case 0x91F3:
                        *str++ = '濯';
                        break;
                    case 0x91F4:
                        *str++ = '琢';
                        break;
                    case 0x91F5:
                        *str++ = '託';
                        break;
                    case 0x91F6:
                        *str++ = '鐸';
                        break;
                    case 0x91F7:
                        *str++ = '濁';
                        break;
                    case 0x91F8:
                        *str++ = '諾';
                        break;
                    case 0x91F9:
                        *str++ = '茸';
                        break;
                    case 0x91FA:
                        *str++ = '凧';
                        break;
                    case 0x91FB:
                        *str++ = '蛸';
                        break;
                    case 0x91FC:
                        *str++ = '只';
                        break;
                    case 0x9240:
                        *str++ = '叩';
                        break;
                    case 0x9241:
                        *str++ = '但';
                        break;
                    case 0x9242:
                        *str++ = '達';
                        break;
                    case 0x9243:
                        *str++ = '辰';
                        break;
                    case 0x9244:
                        *str++ = '奪';
                        break;
                    case 0x9245:
                        *str++ = '脱';
                        break;
                    case 0x9246:
                        *str++ = '巽';
                        break;
                    case 0x9247:
                        *str++ = '竪';
                        break;
                    case 0x9248:
                        *str++ = '辿';
                        break;
                    case 0x9249:
                        *str++ = '棚';
                        break;
                    case 0x924A:
                        *str++ = '谷';
                        break;
                    case 0x924B:
                        *str++ = '狸';
                        break;
                    case 0x924C:
                        *str++ = '鱈';
                        break;
                    case 0x924D:
                        *str++ = '樽';
                        break;
                    case 0x924E:
                        *str++ = '誰';
                        break;
                    case 0x924F:
                        *str++ = '丹';
                        break;
                    case 0x9250:
                        *str++ = '単';
                        break;
                    case 0x9251:
                        *str++ = '嘆';
                        break;
                    case 0x9252:
                        *str++ = '坦';
                        break;
                    case 0x9253:
                        *str++ = '担';
                        break;
                    case 0x9254:
                        *str++ = '探';
                        break;
                    case 0x9255:
                        *str++ = '旦';
                        break;
                    case 0x9256:
                        *str++ = '歎';
                        break;
                    case 0x9257:
                        *str++ = '淡';
                        break;
                    case 0x9258:
                        *str++ = '湛';
                        break;
                    case 0x9259:
                        *str++ = '炭';
                        break;
                    case 0x925A:
                        *str++ = '短';
                        break;
                    case 0x925B:
                        *str++ = '端';
                        break;
                    case 0x925C:
                        *str++ = '箪';
                        break;
                    case 0x925D:
                        *str++ = '綻';
                        break;
                    case 0x925E:
                        *str++ = '耽';
                        break;
                    case 0x925F:
                        *str++ = '胆';
                        break;
                    case 0x9260:
                        *str++ = '蛋';
                        break;
                    case 0x9261:
                        *str++ = '誕';
                        break;
                    case 0x9262:
                        *str++ = '鍛';
                        break;
                    case 0x9263:
                        *str++ = '団';
                        break;
                    case 0x9264:
                        *str++ = '壇';
                        break;
                    case 0x9265:
                        *str++ = '弾';
                        break;
                    case 0x9266:
                        *str++ = '断';
                        break;
                    case 0x9267:
                        *str++ = '暖';
                        break;
                    case 0x9268:
                        *str++ = '檀';
                        break;
                    case 0x9269:
                        *str++ = '段';
                        break;
                    case 0x926A:
                        *str++ = '男';
                        break;
                    case 0x926B:
                        *str++ = '談';
                        break;
                    case 0x926C:
                        *str++ = '値';
                        break;
                    case 0x926D:
                        *str++ = '知';
                        break;
                    case 0x926E:
                        *str++ = '地';
                        break;
                    case 0x926F:
                        *str++ = '弛';
                        break;
                    case 0x9270:
                        *str++ = '恥';
                        break;
                    case 0x9271:
                        *str++ = '智';
                        break;
                    case 0x9272:
                        *str++ = '池';
                        break;
                    case 0x9273:
                        *str++ = '痴';
                        break;
                    case 0x9274:
                        *str++ = '稚';
                        break;
                    case 0x9275:
                        *str++ = '置';
                        break;
                    case 0x9276:
                        *str++ = '致';
                        break;
                    case 0x9277:
                        *str++ = '蜘';
                        break;
                    case 0x9278:
                        *str++ = '遅';
                        break;
                    case 0x9279:
                        *str++ = '馳';
                        break;
                    case 0x927A:
                        *str++ = '築';
                        break;
                    case 0x927B:
                        *str++ = '畜';
                        break;
                    case 0x927C:
                        *str++ = '竹';
                        break;
                    case 0x927D:
                        *str++ = '筑';
                        break;
                    case 0x927E:
                        *str++ = '蓄';
                        break;
                    case 0x9280:
                        *str++ = '逐';
                        break;
                    case 0x9281:
                        *str++ = '秩';
                        break;
                    case 0x9282:
                        *str++ = '窒';
                        break;
                    case 0x9283:
                        *str++ = '茶';
                        break;
                    case 0x9284:
                        *str++ = '嫡';
                        break;
                    case 0x9285:
                        *str++ = '着';
                        break;
                    case 0x9286:
                        *str++ = '中';
                        break;
                    case 0x9287:
                        *str++ = '仲';
                        break;
                    case 0x9288:
                        *str++ = '宙';
                        break;
                    case 0x9289:
                        *str++ = '忠';
                        break;
                    case 0x928A:
                        *str++ = '抽';
                        break;
                    case 0x928B:
                        *str++ = '昼';
                        break;
                    case 0x928C:
                        *str++ = '柱';
                        break;
                    case 0x928D:
                        *str++ = '注';
                        break;
                    case 0x928E:
                        *str++ = '虫';
                        break;
                    case 0x928F:
                        *str++ = '衷';
                        break;
                    case 0x9290:
                        *str++ = '註';
                        break;
                    case 0x9291:
                        *str++ = '酎';
                        break;
                    case 0x9292:
                        *str++ = '鋳';
                        break;
                    case 0x9293:
                        *str++ = '駐';
                        break;
                    case 0x9294:
                        *str++ = '樗';
                        break;
                    case 0x9295:
                        *str++ = '瀦';
                        break;
                    case 0x9296:
                        *str++ = '猪';
                        break;
                    case 0x9297:
                        *str++ = '苧';
                        break;
                    case 0x9298:
                        *str++ = '著';
                        break;
                    case 0x9299:
                        *str++ = '貯';
                        break;
                    case 0x929A:
                        *str++ = '丁';
                        break;
                    case 0x929B:
                        *str++ = '兆';
                        break;
                    case 0x929C:
                        *str++ = '凋';
                        break;
                    case 0x929D:
                        *str++ = '喋';
                        break;
                    case 0x929E:
                        *str++ = '寵';
                        break;
                    case 0x929F:
                        *str++ = '帖';
                        break;
                    case 0x92A0:
                        *str++ = '帳';
                        break;
                    case 0x92A1:
                        *str++ = '庁';
                        break;
                    case 0x92A2:
                        *str++ = '弔';
                        break;
                    case 0x92A3:
                        *str++ = '張';
                        break;
                    case 0x92A4:
                        *str++ = '彫';
                        break;
                    case 0x92A5:
                        *str++ = '徴';
                        break;
                    case 0x92A6:
                        *str++ = '懲';
                        break;
                    case 0x92A7:
                        *str++ = '挑';
                        break;
                    case 0x92A8:
                        *str++ = '暢';
                        break;
                    case 0x92A9:
                        *str++ = '朝';
                        break;
                    case 0x92AA:
                        *str++ = '潮';
                        break;
                    case 0x92AB:
                        *str++ = '牒';
                        break;
                    case 0x92AC:
                        *str++ = '町';
                        break;
                    case 0x92AD:
                        *str++ = '眺';
                        break;
                    case 0x92AE:
                        *str++ = '聴';
                        break;
                    case 0x92AF:
                        *str++ = '脹';
                        break;
                    case 0x92B0:
                        *str++ = '腸';
                        break;
                    case 0x92B1:
                        *str++ = '蝶';
                        break;
                    case 0x92B2:
                        *str++ = '調';
                        break;
                    case 0x92B3:
                        *str++ = '諜';
                        break;
                    case 0x92B4:
                        *str++ = '超';
                        break;
                    case 0x92B5:
                        *str++ = '跳';
                        break;
                    case 0x92B6:
                        *str++ = '銚';
                        break;
                    case 0x92B7:
                        *str++ = '長';
                        break;
                    case 0x92B8:
                        *str++ = '頂';
                        break;
                    case 0x92B9:
                        *str++ = '鳥';
                        break;
                    case 0x92BA:
                        *str++ = '勅';
                        break;
                    case 0x92BB:
                        *str++ = '捗';
                        break;
                    case 0x92BC:
                        *str++ = '直';
                        break;
                    case 0x92BD:
                        *str++ = '朕';
                        break;
                    case 0x92BE:
                        *str++ = '沈';
                        break;
                    case 0x92BF:
                        *str++ = '珍';
                        break;
                    case 0x92C0:
                        *str++ = '賃';
                        break;
                    case 0x92C1:
                        *str++ = '鎮';
                        break;
                    case 0x92C2:
                        *str++ = '陳';
                        break;
                    case 0x92C3:
                        *str++ = '津';
                        break;
                    case 0x92C4:
                        *str++ = '墜';
                        break;
                    case 0x92C5:
                        *str++ = '椎';
                        break;
                    case 0x92C6:
                        *str++ = '槌';
                        break;
                    case 0x92C7:
                        *str++ = '追';
                        break;
                    case 0x92C8:
                        *str++ = '鎚';
                        break;
                    case 0x92C9:
                        *str++ = '痛';
                        break;
                    case 0x92CA:
                        *str++ = '通';
                        break;
                    case 0x92CB:
                        *str++ = '塚';
                        break;
                    case 0x92CC:
                        *str++ = '栂';
                        break;
                    case 0x92CD:
                        *str++ = '掴';
                        break;
                    case 0x92CE:
                        *str++ = '槻';
                        break;
                    case 0x92CF:
                        *str++ = '佃';
                        break;
                    case 0x92D0:
                        *str++ = '漬';
                        break;
                    case 0x92D1:
                        *str++ = '柘';
                        break;
                    case 0x92D2:
                        *str++ = '辻';
                        break;
                    case 0x92D3:
                        *str++ = '蔦';
                        break;
                    case 0x92D4:
                        *str++ = '綴';
                        break;
                    case 0x92D5:
                        *str++ = '鍔';
                        break;
                    case 0x92D6:
                        *str++ = '椿';
                        break;
                    case 0x92D7:
                        *str++ = '潰';
                        break;
                    case 0x92D8:
                        *str++ = '坪';
                        break;
                    case 0x92D9:
                        *str++ = '壷';
                        break;
                    case 0x92DA:
                        *str++ = '嬬';
                        break;
                    case 0x92DB:
                        *str++ = '紬';
                        break;
                    case 0x92DC:
                        *str++ = '爪';
                        break;
                    case 0x92DD:
                        *str++ = '吊';
                        break;
                    case 0x92DE:
                        *str++ = '釣';
                        break;
                    case 0x92DF:
                        *str++ = '鶴';
                        break;
                    case 0x92E0:
                        *str++ = '亭';
                        break;
                    case 0x92E1:
                        *str++ = '低';
                        break;
                    case 0x92E2:
                        *str++ = '停';
                        break;
                    case 0x92E3:
                        *str++ = '偵';
                        break;
                    case 0x92E4:
                        *str++ = '剃';
                        break;
                    case 0x92E5:
                        *str++ = '貞';
                        break;
                    case 0x92E6:
                        *str++ = '呈';
                        break;
                    case 0x92E7:
                        *str++ = '堤';
                        break;
                    case 0x92E8:
                        *str++ = '定';
                        break;
                    case 0x92E9:
                        *str++ = '帝';
                        break;
                    case 0x92EA:
                        *str++ = '底';
                        break;
                    case 0x92EB:
                        *str++ = '庭';
                        break;
                    case 0x92EC:
                        *str++ = '廷';
                        break;
                    case 0x92ED:
                        *str++ = '弟';
                        break;
                    case 0x92EE:
                        *str++ = '悌';
                        break;
                    case 0x92EF:
                        *str++ = '抵';
                        break;
                    case 0x92F0:
                        *str++ = '挺';
                        break;
                    case 0x92F1:
                        *str++ = '提';
                        break;
                    case 0x92F2:
                        *str++ = '梯';
                        break;
                    case 0x92F3:
                        *str++ = '汀';
                        break;
                    case 0x92F4:
                        *str++ = '碇';
                        break;
                    case 0x92F5:
                        *str++ = '禎';
                        break;
                    case 0x92F6:
                        *str++ = '程';
                        break;
                    case 0x92F7:
                        *str++ = '締';
                        break;
                    case 0x92F8:
                        *str++ = '艇';
                        break;
                    case 0x92F9:
                        *str++ = '訂';
                        break;
                    case 0x92FA:
                        *str++ = '諦';
                        break;
                    case 0x92FB:
                        *str++ = '蹄';
                        break;
                    case 0x92FC:
                        *str++ = '逓';
                        break;
                    case 0x9340:
                        *str++ = '邸';
                        break;
                    case 0x9341:
                        *str++ = '鄭';
                        break;
                    case 0x9342:
                        *str++ = '釘';
                        break;
                    case 0x9343:
                        *str++ = '鼎';
                        break;
                    case 0x9344:
                        *str++ = '泥';
                        break;
                    case 0x9345:
                        *str++ = '摘';
                        break;
                    case 0x9346:
                        *str++ = '擢';
                        break;
                    case 0x9347:
                        *str++ = '敵';
                        break;
                    case 0x9348:
                        *str++ = '滴';
                        break;
                    case 0x9349:
                        *str++ = '的';
                        break;
                    case 0x934A:
                        *str++ = '笛';
                        break;
                    case 0x934B:
                        *str++ = '適';
                        break;
                    case 0x934C:
                        *str++ = '鏑';
                        break;
                    case 0x934D:
                        *str++ = '溺';
                        break;
                    case 0x934E:
                        *str++ = '哲';
                        break;
                    case 0x934F:
                        *str++ = '徹';
                        break;
                    case 0x9350:
                        *str++ = '撤';
                        break;
                    case 0x9351:
                        *str++ = '轍';
                        break;
                    case 0x9352:
                        *str++ = '迭';
                        break;
                    case 0x9353:
                        *str++ = '鉄';
                        break;
                    case 0x9354:
                        *str++ = '典';
                        break;
                    case 0x9355:
                        *str++ = '填';
                        break;
                    case 0x9356:
                        *str++ = '天';
                        break;
                    case 0x9357:
                        *str++ = '展';
                        break;
                    case 0x9358:
                        *str++ = '店';
                        break;
                    case 0x9359:
                        *str++ = '添';
                        break;
                    case 0x935A:
                        *str++ = '纏';
                        break;
                    case 0x935B:
                        *str++ = '甜';
                        break;
                    case 0x935C:
                        *str++ = '貼';
                        break;
                    case 0x935D:
                        *str++ = '転';
                        break;
                    case 0x935E:
                        *str++ = '顛';
                        break;
                    case 0x935F:
                        *str++ = '点';
                        break;
                    case 0x9360:
                        *str++ = '伝';
                        break;
                    case 0x9361:
                        *str++ = '殿';
                        break;
                    case 0x9362:
                        *str++ = '澱';
                        break;
                    case 0x9363:
                        *str++ = '田';
                        break;
                    case 0x9364:
                        *str++ = '電';
                        break;
                    case 0x9365:
                        *str++ = '兎';
                        break;
                    case 0x9366:
                        *str++ = '吐';
                        break;
                    case 0x9367:
                        *str++ = '堵';
                        break;
                    case 0x9368:
                        *str++ = '塗';
                        break;
                    case 0x9369:
                        *str++ = '妬';
                        break;
                    case 0x936A:
                        *str++ = '屠';
                        break;
                    case 0x936B:
                        *str++ = '徒';
                        break;
                    case 0x936C:
                        *str++ = '斗';
                        break;
                    case 0x936D:
                        *str++ = '杜';
                        break;
                    case 0x936E:
                        *str++ = '渡';
                        break;
                    case 0x936F:
                        *str++ = '登';
                        break;
                    case 0x9370:
                        *str++ = '菟';
                        break;
                    case 0x9371:
                        *str++ = '賭';
                        break;
                    case 0x9372:
                        *str++ = '途';
                        break;
                    case 0x9373:
                        *str++ = '都';
                        break;
                    case 0x9374:
                        *str++ = '鍍';
                        break;
                    case 0x9375:
                        *str++ = '砥';
                        break;
                    case 0x9376:
                        *str++ = '砺';
                        break;
                    case 0x9377:
                        *str++ = '努';
                        break;
                    case 0x9378:
                        *str++ = '度';
                        break;
                    case 0x9379:
                        *str++ = '土';
                        break;
                    case 0x937A:
                        *str++ = '奴';
                        break;
                    case 0x937B:
                        *str++ = '怒';
                        break;
                    case 0x937C:
                        *str++ = '倒';
                        break;
                    case 0x937D:
                        *str++ = '党';
                        break;
                    case 0x937E:
                        *str++ = '冬';
                        break;
                    case 0x9380:
                        *str++ = '凍';
                        break;
                    case 0x9381:
                        *str++ = '刀';
                        break;
                    case 0x9382:
                        *str++ = '唐';
                        break;
                    case 0x9383:
                        *str++ = '塔';
                        break;
                    case 0x9384:
                        *str++ = '塘';
                        break;
                    case 0x9385:
                        *str++ = '套';
                        break;
                    case 0x9386:
                        *str++ = '宕';
                        break;
                    case 0x9387:
                        *str++ = '島';
                        break;
                    case 0x9388:
                        *str++ = '嶋';
                        break;
                    case 0x9389:
                        *str++ = '悼';
                        break;
                    case 0x938A:
                        *str++ = '投';
                        break;
                    case 0x938B:
                        *str++ = '搭';
                        break;
                    case 0x938C:
                        *str++ = '東';
                        break;
                    case 0x938D:
                        *str++ = '桃';
                        break;
                    case 0x938E:
                        *str++ = '梼';
                        break;
                    case 0x938F:
                        *str++ = '棟';
                        break;
                    case 0x9390:
                        *str++ = '盗';
                        break;
                    case 0x9391:
                        *str++ = '淘';
                        break;
                    case 0x9392:
                        *str++ = '湯';
                        break;
                    case 0x9393:
                        *str++ = '涛';
                        break;
                    case 0x9394:
                        *str++ = '灯';
                        break;
                    case 0x9395:
                        *str++ = '燈';
                        break;
                    case 0x9396:
                        *str++ = '当';
                        break;
                    case 0x9397:
                        *str++ = '痘';
                        break;
                    case 0x9398:
                        *str++ = '祷';
                        break;
                    case 0x9399:
                        *str++ = '等';
                        break;
                    case 0x939A:
                        *str++ = '答';
                        break;
                    case 0x939B:
                        *str++ = '筒';
                        break;
                    case 0x939C:
                        *str++ = '糖';
                        break;
                    case 0x939D:
                        *str++ = '統';
                        break;
                    case 0x939E:
                        *str++ = '到';
                        break;
                    case 0x939F:
                        *str++ = '董';
                        break;
                    case 0x93A0:
                        *str++ = '蕩';
                        break;
                    case 0x93A1:
                        *str++ = '藤';
                        break;
                    case 0x93A2:
                        *str++ = '討';
                        break;
                    case 0x93A3:
                        *str++ = '謄';
                        break;
                    case 0x93A4:
                        *str++ = '豆';
                        break;
                    case 0x93A5:
                        *str++ = '踏';
                        break;
                    case 0x93A6:
                        *str++ = '逃';
                        break;
                    case 0x93A7:
                        *str++ = '透';
                        break;
                    case 0x93A8:
                        *str++ = '鐙';
                        break;
                    case 0x93A9:
                        *str++ = '陶';
                        break;
                    case 0x93AA:
                        *str++ = '頭';
                        break;
                    case 0x93AB:
                        *str++ = '騰';
                        break;
                    case 0x93AC:
                        *str++ = '闘';
                        break;
                    case 0x93AD:
                        *str++ = '働';
                        break;
                    case 0x93AE:
                        *str++ = '動';
                        break;
                    case 0x93AF:
                        *str++ = '同';
                        break;
                    case 0x93B0:
                        *str++ = '堂';
                        break;
                    case 0x93B1:
                        *str++ = '導';
                        break;
                    case 0x93B2:
                        *str++ = '憧';
                        break;
                    case 0x93B3:
                        *str++ = '撞';
                        break;
                    case 0x93B4:
                        *str++ = '洞';
                        break;
                    case 0x93B5:
                        *str++ = '瞳';
                        break;
                    case 0x93B6:
                        *str++ = '童';
                        break;
                    case 0x93B7:
                        *str++ = '胴';
                        break;
                    case 0x93B8:
                        *str++ = '萄';
                        break;
                    case 0x93B9:
                        *str++ = '道';
                        break;
                    case 0x93BA:
                        *str++ = '銅';
                        break;
                    case 0x93BB:
                        *str++ = '峠';
                        break;
                    case 0x93BC:
                        *str++ = '鴇';
                        break;
                    case 0x93BD:
                        *str++ = '匿';
                        break;
                    case 0x93BE:
                        *str++ = '得';
                        break;
                    case 0x93BF:
                        *str++ = '徳';
                        break;
                    case 0x93C0:
                        *str++ = '涜';
                        break;
                    case 0x93C1:
                        *str++ = '特';
                        break;
                    case 0x93C2:
                        *str++ = '督';
                        break;
                    case 0x93C3:
                        *str++ = '禿';
                        break;
                    case 0x93C4:
                        *str++ = '篤';
                        break;
                    case 0x93C5:
                        *str++ = '毒';
                        break;
                    case 0x93C6:
                        *str++ = '独';
                        break;
                    case 0x93C7:
                        *str++ = '読';
                        break;
                    case 0x93C8:
                        *str++ = '栃';
                        break;
                    case 0x93C9:
                        *str++ = '橡';
                        break;
                    case 0x93CA:
                        *str++ = '凸';
                        break;
                    case 0x93CB:
                        *str++ = '突';
                        break;
                    case 0x93CC:
                        *str++ = '椴';
                        break;
                    case 0x93CD:
                        *str++ = '届';
                        break;
                    case 0x93CE:
                        *str++ = '鳶';
                        break;
                    case 0x93CF:
                        *str++ = '苫';
                        break;
                    case 0x93D0:
                        *str++ = '寅';
                        break;
                    case 0x93D1:
                        *str++ = '酉';
                        break;
                    case 0x93D2:
                        *str++ = '瀞';
                        break;
                    case 0x93D3:
                        *str++ = '噸';
                        break;
                    case 0x93D4:
                        *str++ = '屯';
                        break;
                    case 0x93D5:
                        *str++ = '惇';
                        break;
                    case 0x93D6:
                        *str++ = '敦';
                        break;
                    case 0x93D7:
                        *str++ = '沌';
                        break;
                    case 0x93D8:
                        *str++ = '豚';
                        break;
                    case 0x93D9:
                        *str++ = '遁';
                        break;
                    case 0x93DA:
                        *str++ = '頓';
                        break;
                    case 0x93DB:
                        *str++ = '呑';
                        break;
                    case 0x93DC:
                        *str++ = '曇';
                        break;
                    case 0x93DD:
                        *str++ = '鈍';
                        break;
                    case 0x93DE:
                        *str++ = '奈';
                        break;
                    case 0x93DF:
                        *str++ = '那';
                        break;
                    case 0x93E0:
                        *str++ = '内';
                        break;
                    case 0x93E1:
                        *str++ = '乍';
                        break;
                    case 0x93E2:
                        *str++ = '凪';
                        break;
                    case 0x93E3:
                        *str++ = '薙';
                        break;
                    case 0x93E4:
                        *str++ = '謎';
                        break;
                    case 0x93E5:
                        *str++ = '灘';
                        break;
                    case 0x93E6:
                        *str++ = '捺';
                        break;
                    case 0x93E7:
                        *str++ = '鍋';
                        break;
                    case 0x93E8:
                        *str++ = '楢';
                        break;
                    case 0x93E9:
                        *str++ = '馴';
                        break;
                    case 0x93EA:
                        *str++ = '縄';
                        break;
                    case 0x93EB:
                        *str++ = '畷';
                        break;
                    case 0x93EC:
                        *str++ = '南';
                        break;
                    case 0x93ED:
                        *str++ = '楠';
                        break;
                    case 0x93EE:
                        *str++ = '軟';
                        break;
                    case 0x93EF:
                        *str++ = '難';
                        break;
                    case 0x93F0:
                        *str++ = '汝';
                        break;
                    case 0x93F1:
                        *str++ = '二';
                        break;
                    case 0x93F2:
                        *str++ = '尼';
                        break;
                    case 0x93F3:
                        *str++ = '弐';
                        break;
                    case 0x93F4:
                        *str++ = '迩';
                        break;
                    case 0x93F5:
                        *str++ = '匂';
                        break;
                    case 0x93F6:
                        *str++ = '賑';
                        break;
                    case 0x93F7:
                        *str++ = '肉';
                        break;
                    case 0x93F8:
                        *str++ = '虹';
                        break;
                    case 0x93F9:
                        *str++ = '廿';
                        break;
                    case 0x93FA:
                        *str++ = '日';
                        break;
                    case 0x93FB:
                        *str++ = '乳';
                        break;
                    case 0x93FC:
                        *str++ = '入';
                        break;
                    case 0x9440:
                        *str++ = '如';
                        break;
                    case 0x9441:
                        *str++ = '尿';
                        break;
                    case 0x9442:
                        *str++ = '韮';
                        break;
                    case 0x9443:
                        *str++ = '任';
                        break;
                    case 0x9444:
                        *str++ = '妊';
                        break;
                    case 0x9445:
                        *str++ = '忍';
                        break;
                    case 0x9446:
                        *str++ = '認';
                        break;
                    case 0x9447:
                        *str++ = '濡';
                        break;
                    case 0x9448:
                        *str++ = '禰';
                        break;
                    case 0x9449:
                        *str++ = '祢';
                        break;
                    case 0x944A:
                        *str++ = '寧';
                        break;
                    case 0x944B:
                        *str++ = '葱';
                        break;
                    case 0x944C:
                        *str++ = '猫';
                        break;
                    case 0x944D:
                        *str++ = '熱';
                        break;
                    case 0x944E:
                        *str++ = '年';
                        break;
                    case 0x944F:
                        *str++ = '念';
                        break;
                    case 0x9450:
                        *str++ = '捻';
                        break;
                    case 0x9451:
                        *str++ = '撚';
                        break;
                    case 0x9452:
                        *str++ = '燃';
                        break;
                    case 0x9453:
                        *str++ = '粘';
                        break;
                    case 0x9454:
                        *str++ = '乃';
                        break;
                    case 0x9455:
                        *str++ = '廼';
                        break;
                    case 0x9456:
                        *str++ = '之';
                        break;
                    case 0x9457:
                        *str++ = '埜';
                        break;
                    case 0x9458:
                        *str++ = '嚢';
                        break;
                    case 0x9459:
                        *str++ = '悩';
                        break;
                    case 0x945A:
                        *str++ = '濃';
                        break;
                    case 0x945B:
                        *str++ = '納';
                        break;
                    case 0x945C:
                        *str++ = '能';
                        break;
                    case 0x945D:
                        *str++ = '脳';
                        break;
                    case 0x945E:
                        *str++ = '膿';
                        break;
                    case 0x945F:
                        *str++ = '農';
                        break;
                    case 0x9460:
                        *str++ = '覗';
                        break;
                    case 0x9461:
                        *str++ = '蚤';
                        break;
                    case 0x9462:
                        *str++ = '巴';
                        break;
                    case 0x9463:
                        *str++ = '把';
                        break;
                    case 0x9464:
                        *str++ = '播';
                        break;
                    case 0x9465:
                        *str++ = '覇';
                        break;
                    case 0x9466:
                        *str++ = '杷';
                        break;
                    case 0x9467:
                        *str++ = '波';
                        break;
                    case 0x9468:
                        *str++ = '派';
                        break;
                    case 0x9469:
                        *str++ = '琶';
                        break;
                    case 0x946A:
                        *str++ = '破';
                        break;
                    case 0x946B:
                        *str++ = '婆';
                        break;
                    case 0x946C:
                        *str++ = '罵';
                        break;
                    case 0x946D:
                        *str++ = '芭';
                        break;
                    case 0x946E:
                        *str++ = '馬';
                        break;
                    case 0x946F:
                        *str++ = '俳';
                        break;
                    case 0x9470:
                        *str++ = '廃';
                        break;
                    case 0x9471:
                        *str++ = '拝';
                        break;
                    case 0x9472:
                        *str++ = '排';
                        break;
                    case 0x9473:
                        *str++ = '敗';
                        break;
                    case 0x9474:
                        *str++ = '杯';
                        break;
                    case 0x9475:
                        *str++ = '盃';
                        break;
                    case 0x9476:
                        *str++ = '牌';
                        break;
                    case 0x9477:
                        *str++ = '背';
                        break;
                    case 0x9478:
                        *str++ = '肺';
                        break;
                    case 0x9479:
                        *str++ = '輩';
                        break;
                    case 0x947A:
                        *str++ = '配';
                        break;
                    case 0x947B:
                        *str++ = '倍';
                        break;
                    case 0x947C:
                        *str++ = '培';
                        break;
                    case 0x947D:
                        *str++ = '媒';
                        break;
                    case 0x947E:
                        *str++ = '梅';
                        break;
                    case 0x9480:
                        *str++ = '楳';
                        break;
                    case 0x9481:
                        *str++ = '煤';
                        break;
                    case 0x9482:
                        *str++ = '狽';
                        break;
                    case 0x9483:
                        *str++ = '買';
                        break;
                    case 0x9484:
                        *str++ = '売';
                        break;
                    case 0x9485:
                        *str++ = '賠';
                        break;
                    case 0x9486:
                        *str++ = '陪';
                        break;
                    case 0x9487:
                        *str++ = '這';
                        break;
                    case 0x9488:
                        *str++ = '蝿';
                        break;
                    case 0x9489:
                        *str++ = '秤';
                        break;
                    case 0x948A:
                        *str++ = '矧';
                        break;
                    case 0x948B:
                        *str++ = '萩';
                        break;
                    case 0x948C:
                        *str++ = '伯';
                        break;
                    case 0x948D:
                        *str++ = '剥';
                        break;
                    case 0x948E:
                        *str++ = '博';
                        break;
                    case 0x948F:
                        *str++ = '拍';
                        break;
                    case 0x9490:
                        *str++ = '柏';
                        break;
                    case 0x9491:
                        *str++ = '泊';
                        break;
                    case 0x9492:
                        *str++ = '白';
                        break;
                    case 0x9493:
                        *str++ = '箔';
                        break;
                    case 0x9494:
                        *str++ = '粕';
                        break;
                    case 0x9495:
                        *str++ = '舶';
                        break;
                    case 0x9496:
                        *str++ = '薄';
                        break;
                    case 0x9497:
                        *str++ = '迫';
                        break;
                    case 0x9498:
                        *str++ = '曝';
                        break;
                    case 0x9499:
                        *str++ = '漠';
                        break;
                    case 0x949A:
                        *str++ = '爆';
                        break;
                    case 0x949B:
                        *str++ = '縛';
                        break;
                    case 0x949C:
                        *str++ = '莫';
                        break;
                    case 0x949D:
                        *str++ = '駁';
                        break;
                    case 0x949E:
                        *str++ = '麦';
                        break;
                    case 0x949F:
                        *str++ = '函';
                        break;
                    case 0x94A0:
                        *str++ = '箱';
                        break;
                    case 0x94A1:
                        *str++ = '硲';
                        break;
                    case 0x94A2:
                        *str++ = '箸';
                        break;
                    case 0x94A3:
                        *str++ = '肇';
                        break;
                    case 0x94A4:
                        *str++ = '筈';
                        break;
                    case 0x94A5:
                        *str++ = '櫨';
                        break;
                    case 0x94A6:
                        *str++ = '幡';
                        break;
                    case 0x94A7:
                        *str++ = '肌';
                        break;
                    case 0x94A8:
                        *str++ = '畑';
                        break;
                    case 0x94A9:
                        *str++ = '畠';
                        break;
                    case 0x94AA:
                        *str++ = '八';
                        break;
                    case 0x94AB:
                        *str++ = '鉢';
                        break;
                    case 0x94AC:
                        *str++ = '溌';
                        break;
                    case 0x94AD:
                        *str++ = '発';
                        break;
                    case 0x94AE:
                        *str++ = '醗';
                        break;
                    case 0x94AF:
                        *str++ = '髪';
                        break;
                    case 0x94B0:
                        *str++ = '伐';
                        break;
                    case 0x94B1:
                        *str++ = '罰';
                        break;
                    case 0x94B2:
                        *str++ = '抜';
                        break;
                    case 0x94B3:
                        *str++ = '筏';
                        break;
                    case 0x94B4:
                        *str++ = '閥';
                        break;
                    case 0x94B5:
                        *str++ = '鳩';
                        break;
                    case 0x94B6:
                        *str++ = '噺';
                        break;
                    case 0x94B7:
                        *str++ = '塙';
                        break;
                    case 0x94B8:
                        *str++ = '蛤';
                        break;
                    case 0x94B9:
                        *str++ = '隼';
                        break;
                    case 0x94BA:
                        *str++ = '伴';
                        break;
                    case 0x94BB:
                        *str++ = '判';
                        break;
                    case 0x94BC:
                        *str++ = '半';
                        break;
                    case 0x94BD:
                        *str++ = '反';
                        break;
                    case 0x94BE:
                        *str++ = '叛';
                        break;
                    case 0x94BF:
                        *str++ = '帆';
                        break;
                    case 0x94C0:
                        *str++ = '搬';
                        break;
                    case 0x94C1:
                        *str++ = '斑';
                        break;
                    case 0x94C2:
                        *str++ = '板';
                        break;
                    case 0x94C3:
                        *str++ = '氾';
                        break;
                    case 0x94C4:
                        *str++ = '汎';
                        break;
                    case 0x94C5:
                        *str++ = '版';
                        break;
                    case 0x94C6:
                        *str++ = '犯';
                        break;
                    case 0x94C7:
                        *str++ = '班';
                        break;
                    case 0x94C8:
                        *str++ = '畔';
                        break;
                    case 0x94C9:
                        *str++ = '繁';
                        break;
                    case 0x94CA:
                        *str++ = '般';
                        break;
                    case 0x94CB:
                        *str++ = '藩';
                        break;
                    case 0x94CC:
                        *str++ = '販';
                        break;
                    case 0x94CD:
                        *str++ = '範';
                        break;
                    case 0x94CE:
                        *str++ = '釆';
                        break;
                    case 0x94CF:
                        *str++ = '煩';
                        break;
                    case 0x94D0:
                        *str++ = '頒';
                        break;
                    case 0x94D1:
                        *str++ = '飯';
                        break;
                    case 0x94D2:
                        *str++ = '挽';
                        break;
                    case 0x94D3:
                        *str++ = '晩';
                        break;
                    case 0x94D4:
                        *str++ = '番';
                        break;
                    case 0x94D5:
                        *str++ = '盤';
                        break;
                    case 0x94D6:
                        *str++ = '磐';
                        break;
                    case 0x94D7:
                        *str++ = '蕃';
                        break;
                    case 0x94D8:
                        *str++ = '蛮';
                        break;
                    case 0x94D9:
                        *str++ = '匪';
                        break;
                    case 0x94DA:
                        *str++ = '卑';
                        break;
                    case 0x94DB:
                        *str++ = '否';
                        break;
                    case 0x94DC:
                        *str++ = '妃';
                        break;
                    case 0x94DD:
                        *str++ = '庇';
                        break;
                    case 0x94DE:
                        *str++ = '彼';
                        break;
                    case 0x94DF:
                        *str++ = '悲';
                        break;
                    case 0x94E0:
                        *str++ = '扉';
                        break;
                    case 0x94E1:
                        *str++ = '批';
                        break;
                    case 0x94E2:
                        *str++ = '披';
                        break;
                    case 0x94E3:
                        *str++ = '斐';
                        break;
                    case 0x94E4:
                        *str++ = '比';
                        break;
                    case 0x94E5:
                        *str++ = '泌';
                        break;
                    case 0x94E6:
                        *str++ = '疲';
                        break;
                    case 0x94E7:
                        *str++ = '皮';
                        break;
                    case 0x94E8:
                        *str++ = '碑';
                        break;
                    case 0x94E9:
                        *str++ = '秘';
                        break;
                    case 0x94EA:
                        *str++ = '緋';
                        break;
                    case 0x94EB:
                        *str++ = '罷';
                        break;
                    case 0x94EC:
                        *str++ = '肥';
                        break;
                    case 0x94ED:
                        *str++ = '被';
                        break;
                    case 0x94EE:
                        *str++ = '誹';
                        break;
                    case 0x94EF:
                        *str++ = '費';
                        break;
                    case 0x94F0:
                        *str++ = '避';
                        break;
                    case 0x94F1:
                        *str++ = '非';
                        break;
                    case 0x94F2:
                        *str++ = '飛';
                        break;
                    case 0x94F3:
                        *str++ = '樋';
                        break;
                    case 0x94F4:
                        *str++ = '簸';
                        break;
                    case 0x94F5:
                        *str++ = '備';
                        break;
                    case 0x94F6:
                        *str++ = '尾';
                        break;
                    case 0x94F7:
                        *str++ = '微';
                        break;
                    case 0x94F8:
                        *str++ = '枇';
                        break;
                    case 0x94F9:
                        *str++ = '毘';
                        break;
                    case 0x94FA:
                        *str++ = '琵';
                        break;
                    case 0x94FB:
                        *str++ = '眉';
                        break;
                    case 0x94FC:
                        *str++ = '美';
                        break;
                    case 0x9540:
                        *str++ = '鼻';
                        break;
                    case 0x9541:
                        *str++ = '柊';
                        break;
                    case 0x9542:
                        *str++ = '稗';
                        break;
                    case 0x9543:
                        *str++ = '匹';
                        break;
                    case 0x9544:
                        *str++ = '疋';
                        break;
                    case 0x9545:
                        *str++ = '髭';
                        break;
                    case 0x9546:
                        *str++ = '彦';
                        break;
                    case 0x9547:
                        *str++ = '膝';
                        break;
                    case 0x9548:
                        *str++ = '菱';
                        break;
                    case 0x9549:
                        *str++ = '肘';
                        break;
                    case 0x954A:
                        *str++ = '弼';
                        break;
                    case 0x954B:
                        *str++ = '必';
                        break;
                    case 0x954C:
                        *str++ = '畢';
                        break;
                    case 0x954D:
                        *str++ = '筆';
                        break;
                    case 0x954E:
                        *str++ = '逼';
                        break;
                    case 0x954F:
                        *str++ = '桧';
                        break;
                    case 0x9550:
                        *str++ = '姫';
                        break;
                    case 0x9551:
                        *str++ = '媛';
                        break;
                    case 0x9552:
                        *str++ = '紐';
                        break;
                    case 0x9553:
                        *str++ = '百';
                        break;
                    case 0x9554:
                        *str++ = '謬';
                        break;
                    case 0x9555:
                        *str++ = '俵';
                        break;
                    case 0x9556:
                        *str++ = '彪';
                        break;
                    case 0x9557:
                        *str++ = '標';
                        break;
                    case 0x9558:
                        *str++ = '氷';
                        break;
                    case 0x9559:
                        *str++ = '漂';
                        break;
                    case 0x955A:
                        *str++ = '瓢';
                        break;
                    case 0x955B:
                        *str++ = '票';
                        break;
                    case 0x955C:
                        *str++ = '表';
                        break;
                    case 0x955D:
                        *str++ = '評';
                        break;
                    case 0x955E:
                        *str++ = '豹';
                        break;
                    case 0x955F:
                        *str++ = '廟';
                        break;
                    case 0x9560:
                        *str++ = '描';
                        break;
                    case 0x9561:
                        *str++ = '病';
                        break;
                    case 0x9562:
                        *str++ = '秒';
                        break;
                    case 0x9563:
                        *str++ = '苗';
                        break;
                    case 0x9564:
                        *str++ = '錨';
                        break;
                    case 0x9565:
                        *str++ = '鋲';
                        break;
                    case 0x9566:
                        *str++ = '蒜';
                        break;
                    case 0x9567:
                        *str++ = '蛭';
                        break;
                    case 0x9568:
                        *str++ = '鰭';
                        break;
                    case 0x9569:
                        *str++ = '品';
                        break;
                    case 0x956A:
                        *str++ = '彬';
                        break;
                    case 0x956B:
                        *str++ = '斌';
                        break;
                    case 0x956C:
                        *str++ = '浜';
                        break;
                    case 0x956D:
                        *str++ = '瀕';
                        break;
                    case 0x956E:
                        *str++ = '貧';
                        break;
                    case 0x956F:
                        *str++ = '賓';
                        break;
                    case 0x9570:
                        *str++ = '頻';
                        break;
                    case 0x9571:
                        *str++ = '敏';
                        break;
                    case 0x9572:
                        *str++ = '瓶';
                        break;
                    case 0x9573:
                        *str++ = '不';
                        break;
                    case 0x9574:
                        *str++ = '付';
                        break;
                    case 0x9575:
                        *str++ = '埠';
                        break;
                    case 0x9576:
                        *str++ = '夫';
                        break;
                    case 0x9577:
                        *str++ = '婦';
                        break;
                    case 0x9578:
                        *str++ = '富';
                        break;
                    case 0x9579:
                        *str++ = '冨';
                        break;
                    case 0x957A:
                        *str++ = '布';
                        break;
                    case 0x957B:
                        *str++ = '府';
                        break;
                    case 0x957C:
                        *str++ = '怖';
                        break;
                    case 0x957D:
                        *str++ = '扶';
                        break;
                    case 0x957E:
                        *str++ = '敷';
                        break;
                    case 0x9580:
                        *str++ = '斧';
                        break;
                    case 0x9581:
                        *str++ = '普';
                        break;
                    case 0x9582:
                        *str++ = '浮';
                        break;
                    case 0x9583:
                        *str++ = '父';
                        break;
                    case 0x9584:
                        *str++ = '符';
                        break;
                    case 0x9585:
                        *str++ = '腐';
                        break;
                    case 0x9586:
                        *str++ = '膚';
                        break;
                    case 0x9587:
                        *str++ = '芙';
                        break;
                    case 0x9588:
                        *str++ = '譜';
                        break;
                    case 0x9589:
                        *str++ = '負';
                        break;
                    case 0x958A:
                        *str++ = '賦';
                        break;
                    case 0x958B:
                        *str++ = '赴';
                        break;
                    case 0x958C:
                        *str++ = '阜';
                        break;
                    case 0x958D:
                        *str++ = '附';
                        break;
                    case 0x958E:
                        *str++ = '侮';
                        break;
                    case 0x958F:
                        *str++ = '撫';
                        break;
                    case 0x9590:
                        *str++ = '武';
                        break;
                    case 0x9591:
                        *str++ = '舞';
                        break;
                    case 0x9592:
                        *str++ = '葡';
                        break;
                    case 0x9593:
                        *str++ = '蕪';
                        break;
                    case 0x9594:
                        *str++ = '部';
                        break;
                    case 0x9595:
                        *str++ = '封';
                        break;
                    case 0x9596:
                        *str++ = '楓';
                        break;
                    case 0x9597:
                        *str++ = '風';
                        break;
                    case 0x9598:
                        *str++ = '葺';
                        break;
                    case 0x9599:
                        *str++ = '蕗';
                        break;
                    case 0x959A:
                        *str++ = '伏';
                        break;
                    case 0x959B:
                        *str++ = '副';
                        break;
                    case 0x959C:
                        *str++ = '復';
                        break;
                    case 0x959D:
                        *str++ = '幅';
                        break;
                    case 0x959E:
                        *str++ = '服';
                        break;
                    case 0x959F:
                        *str++ = '福';
                        break;
                    case 0x95A0:
                        *str++ = '腹';
                        break;
                    case 0x95A1:
                        *str++ = '複';
                        break;
                    case 0x95A2:
                        *str++ = '覆';
                        break;
                    case 0x95A3:
                        *str++ = '淵';
                        break;
                    case 0x95A4:
                        *str++ = '弗';
                        break;
                    case 0x95A5:
                        *str++ = '払';
                        break;
                    case 0x95A6:
                        *str++ = '沸';
                        break;
                    case 0x95A7:
                        *str++ = '仏';
                        break;
                    case 0x95A8:
                        *str++ = '物';
                        break;
                    case 0x95A9:
                        *str++ = '鮒';
                        break;
                    case 0x95AA:
                        *str++ = '分';
                        break;
                    case 0x95AB:
                        *str++ = '吻';
                        break;
                    case 0x95AC:
                        *str++ = '噴';
                        break;
                    case 0x95AD:
                        *str++ = '墳';
                        break;
                    case 0x95AE:
                        *str++ = '憤';
                        break;
                    case 0x95AF:
                        *str++ = '扮';
                        break;
                    case 0x95B0:
                        *str++ = '焚';
                        break;
                    case 0x95B1:
                        *str++ = '奮';
                        break;
                    case 0x95B2:
                        *str++ = '粉';
                        break;
                    case 0x95B3:
                        *str++ = '糞';
                        break;
                    case 0x95B4:
                        *str++ = '紛';
                        break;
                    case 0x95B5:
                        *str++ = '雰';
                        break;
                    case 0x95B6:
                        *str++ = '文';
                        break;
                    case 0x95B7:
                        *str++ = '聞';
                        break;
                    case 0x95B8:
                        *str++ = '丙';
                        break;
                    case 0x95B9:
                        *str++ = '併';
                        break;
                    case 0x95BA:
                        *str++ = '兵';
                        break;
                    case 0x95BB:
                        *str++ = '塀';
                        break;
                    case 0x95BC:
                        *str++ = '幣';
                        break;
                    case 0x95BD:
                        *str++ = '平';
                        break;
                    case 0x95BE:
                        *str++ = '弊';
                        break;
                    case 0x95BF:
                        *str++ = '柄';
                        break;
                    case 0x95C0:
                        *str++ = '並';
                        break;
                    case 0x95C1:
                        *str++ = '蔽';
                        break;
                    case 0x95C2:
                        *str++ = '閉';
                        break;
                    case 0x95C3:
                        *str++ = '陛';
                        break;
                    case 0x95C4:
                        *str++ = '米';
                        break;
                    case 0x95C5:
                        *str++ = '頁';
                        break;
                    case 0x95C6:
                        *str++ = '僻';
                        break;
                    case 0x95C7:
                        *str++ = '壁';
                        break;
                    case 0x95C8:
                        *str++ = '癖';
                        break;
                    case 0x95C9:
                        *str++ = '碧';
                        break;
                    case 0x95CA:
                        *str++ = '別';
                        break;
                    case 0x95CB:
                        *str++ = '瞥';
                        break;
                    case 0x95CC:
                        *str++ = '蔑';
                        break;
                    case 0x95CD:
                        *str++ = '箆';
                        break;
                    case 0x95CE:
                        *str++ = '偏';
                        break;
                    case 0x95CF:
                        *str++ = '変';
                        break;
                    case 0x95D0:
                        *str++ = '片';
                        break;
                    case 0x95D1:
                        *str++ = '篇';
                        break;
                    case 0x95D2:
                        *str++ = '編';
                        break;
                    case 0x95D3:
                        *str++ = '辺';
                        break;
                    case 0x95D4:
                        *str++ = '返';
                        break;
                    case 0x95D5:
                        *str++ = '遍';
                        break;
                    case 0x95D6:
                        *str++ = '便';
                        break;
                    case 0x95D7:
                        *str++ = '勉';
                        break;
                    case 0x95D8:
                        *str++ = '娩';
                        break;
                    case 0x95D9:
                        *str++ = '弁';
                        break;
                    case 0x95DA:
                        *str++ = '鞭';
                        break;
                    case 0x95DB:
                        *str++ = '保';
                        break;
                    case 0x95DC:
                        *str++ = '舗';
                        break;
                    case 0x95DD:
                        *str++ = '鋪';
                        break;
                    case 0x95DE:
                        *str++ = '圃';
                        break;
                    case 0x95DF:
                        *str++ = '捕';
                        break;
                    case 0x95E0:
                        *str++ = '歩';
                        break;
                    case 0x95E1:
                        *str++ = '甫';
                        break;
                    case 0x95E2:
                        *str++ = '補';
                        break;
                    case 0x95E3:
                        *str++ = '輔';
                        break;
                    case 0x95E4:
                        *str++ = '穂';
                        break;
                    case 0x95E5:
                        *str++ = '募';
                        break;
                    case 0x95E6:
                        *str++ = '墓';
                        break;
                    case 0x95E7:
                        *str++ = '慕';
                        break;
                    case 0x95E8:
                        *str++ = '戊';
                        break;
                    case 0x95E9:
                        *str++ = '暮';
                        break;
                    case 0x95EA:
                        *str++ = '母';
                        break;
                    case 0x95EB:
                        *str++ = '簿';
                        break;
                    case 0x95EC:
                        *str++ = '菩';
                        break;
                    case 0x95ED:
                        *str++ = '倣';
                        break;
                    case 0x95EE:
                        *str++ = '俸';
                        break;
                    case 0x95EF:
                        *str++ = '包';
                        break;
                    case 0x95F0:
                        *str++ = '呆';
                        break;
                    case 0x95F1:
                        *str++ = '報';
                        break;
                    case 0x95F2:
                        *str++ = '奉';
                        break;
                    case 0x95F3:
                        *str++ = '宝';
                        break;
                    case 0x95F4:
                        *str++ = '峰';
                        break;
                    case 0x95F5:
                        *str++ = '峯';
                        break;
                    case 0x95F6:
                        *str++ = '崩';
                        break;
                    case 0x95F7:
                        *str++ = '庖';
                        break;
                    case 0x95F8:
                        *str++ = '抱';
                        break;
                    case 0x95F9:
                        *str++ = '捧';
                        break;
                    case 0x95FA:
                        *str++ = '放';
                        break;
                    case 0x95FB:
                        *str++ = '方';
                        break;
                    case 0x95FC:
                        *str++ = '朋';
                        break;
                    case 0x9640:
                        *str++ = '法';
                        break;
                    case 0x9641:
                        *str++ = '泡';
                        break;
                    case 0x9642:
                        *str++ = '烹';
                        break;
                    case 0x9643:
                        *str++ = '砲';
                        break;
                    case 0x9644:
                        *str++ = '縫';
                        break;
                    case 0x9645:
                        *str++ = '胞';
                        break;
                    case 0x9646:
                        *str++ = '芳';
                        break;
                    case 0x9647:
                        *str++ = '萌';
                        break;
                    case 0x9648:
                        *str++ = '蓬';
                        break;
                    case 0x9649:
                        *str++ = '蜂';
                        break;
                    case 0x964A:
                        *str++ = '褒';
                        break;
                    case 0x964B:
                        *str++ = '訪';
                        break;
                    case 0x964C:
                        *str++ = '豊';
                        break;
                    case 0x964D:
                        *str++ = '邦';
                        break;
                    case 0x964E:
                        *str++ = '鋒';
                        break;
                    case 0x964F:
                        *str++ = '飽';
                        break;
                    case 0x9650:
                        *str++ = '鳳';
                        break;
                    case 0x9651:
                        *str++ = '鵬';
                        break;
                    case 0x9652:
                        *str++ = '乏';
                        break;
                    case 0x9653:
                        *str++ = '亡';
                        break;
                    case 0x9654:
                        *str++ = '傍';
                        break;
                    case 0x9655:
                        *str++ = '剖';
                        break;
                    case 0x9656:
                        *str++ = '坊';
                        break;
                    case 0x9657:
                        *str++ = '妨';
                        break;
                    case 0x9658:
                        *str++ = '帽';
                        break;
                    case 0x9659:
                        *str++ = '忘';
                        break;
                    case 0x965A:
                        *str++ = '忙';
                        break;
                    case 0x965B:
                        *str++ = '房';
                        break;
                    case 0x965C:
                        *str++ = '暴';
                        break;
                    case 0x965D:
                        *str++ = '望';
                        break;
                    case 0x965E:
                        *str++ = '某';
                        break;
                    case 0x965F:
                        *str++ = '棒';
                        break;
                    case 0x9660:
                        *str++ = '冒';
                        break;
                    case 0x9661:
                        *str++ = '紡';
                        break;
                    case 0x9662:
                        *str++ = '肪';
                        break;
                    case 0x9663:
                        *str++ = '膨';
                        break;
                    case 0x9664:
                        *str++ = '謀';
                        break;
                    case 0x9665:
                        *str++ = '貌';
                        break;
                    case 0x9666:
                        *str++ = '貿';
                        break;
                    case 0x9667:
                        *str++ = '鉾';
                        break;
                    case 0x9668:
                        *str++ = '防';
                        break;
                    case 0x9669:
                        *str++ = '吠';
                        break;
                    case 0x966A:
                        *str++ = '頬';
                        break;
                    case 0x966B:
                        *str++ = '北';
                        break;
                    case 0x966C:
                        *str++ = '僕';
                        break;
                    case 0x966D:
                        *str++ = '卜';
                        break;
                    case 0x966E:
                        *str++ = '墨';
                        break;
                    case 0x966F:
                        *str++ = '撲';
                        break;
                    case 0x9670:
                        *str++ = '朴';
                        break;
                    case 0x9671:
                        *str++ = '牧';
                        break;
                    case 0x9672:
                        *str++ = '睦';
                        break;
                    case 0x9673:
                        *str++ = '穆';
                        break;
                    case 0x9674:
                        *str++ = '釦';
                        break;
                    case 0x9675:
                        *str++ = '勃';
                        break;
                    case 0x9676:
                        *str++ = '没';
                        break;
                    case 0x9677:
                        *str++ = '殆';
                        break;
                    case 0x9678:
                        *str++ = '堀';
                        break;
                    case 0x9679:
                        *str++ = '幌';
                        break;
                    case 0x967A:
                        *str++ = '奔';
                        break;
                    case 0x967B:
                        *str++ = '本';
                        break;
                    case 0x967C:
                        *str++ = '翻';
                        break;
                    case 0x967D:
                        *str++ = '凡';
                        break;
                    case 0x967E:
                        *str++ = '盆';
                        break;
                    case 0x9680:
                        *str++ = '摩';
                        break;
                    case 0x9681:
                        *str++ = '磨';
                        break;
                    case 0x9682:
                        *str++ = '魔';
                        break;
                    case 0x9683:
                        *str++ = '麻';
                        break;
                    case 0x9684:
                        *str++ = '埋';
                        break;
                    case 0x9685:
                        *str++ = '妹';
                        break;
                    case 0x9686:
                        *str++ = '昧';
                        break;
                    case 0x9687:
                        *str++ = '枚';
                        break;
                    case 0x9688:
                        *str++ = '毎';
                        break;
                    case 0x9689:
                        *str++ = '哩';
                        break;
                    case 0x968A:
                        *str++ = '槙';
                        break;
                    case 0x968B:
                        *str++ = '幕';
                        break;
                    case 0x968C:
                        *str++ = '膜';
                        break;
                    case 0x968D:
                        *str++ = '枕';
                        break;
                    case 0x968E:
                        *str++ = '鮪';
                        break;
                    case 0x968F:
                        *str++ = '柾';
                        break;
                    case 0x9690:
                        *str++ = '鱒';
                        break;
                    case 0x9691:
                        *str++ = '桝';
                        break;
                    case 0x9692:
                        *str++ = '亦';
                        break;
                    case 0x9693:
                        *str++ = '俣';
                        break;
                    case 0x9694:
                        *str++ = '又';
                        break;
                    case 0x9695:
                        *str++ = '抹';
                        break;
                    case 0x9696:
                        *str++ = '末';
                        break;
                    case 0x9697:
                        *str++ = '沫';
                        break;
                    case 0x9698:
                        *str++ = '迄';
                        break;
                    case 0x9699:
                        *str++ = '侭';
                        break;
                    case 0x969A:
                        *str++ = '繭';
                        break;
                    case 0x969B:
                        *str++ = '麿';
                        break;
                    case 0x969C:
                        *str++ = '万';
                        break;
                    case 0x969D:
                        *str++ = '慢';
                        break;
                    case 0x969E:
                        *str++ = '満';
                        break;
                    case 0x969F:
                        *str++ = '漫';
                        break;
                    case 0x96A0:
                        *str++ = '蔓';
                        break;
                    case 0x96A1:
                        *str++ = '味';
                        break;
                    case 0x96A2:
                        *str++ = '未';
                        break;
                    case 0x96A3:
                        *str++ = '魅';
                        break;
                    case 0x96A4:
                        *str++ = '巳';
                        break;
                    case 0x96A5:
                        *str++ = '箕';
                        break;
                    case 0x96A6:
                        *str++ = '岬';
                        break;
                    case 0x96A7:
                        *str++ = '密';
                        break;
                    case 0x96A8:
                        *str++ = '蜜';
                        break;
                    case 0x96A9:
                        *str++ = '湊';
                        break;
                    case 0x96AA:
                        *str++ = '蓑';
                        break;
                    case 0x96AB:
                        *str++ = '稔';
                        break;
                    case 0x96AC:
                        *str++ = '脈';
                        break;
                    case 0x96AD:
                        *str++ = '妙';
                        break;
                    case 0x96AE:
                        *str++ = '粍';
                        break;
                    case 0x96AF:
                        *str++ = '民';
                        break;
                    case 0x96B0:
                        *str++ = '眠';
                        break;
                    case 0x96B1:
                        *str++ = '務';
                        break;
                    case 0x96B2:
                        *str++ = '夢';
                        break;
                    case 0x96B3:
                        *str++ = '無';
                        break;
                    case 0x96B4:
                        *str++ = '牟';
                        break;
                    case 0x96B5:
                        *str++ = '矛';
                        break;
                    case 0x96B6:
                        *str++ = '霧';
                        break;
                    case 0x96B7:
                        *str++ = '鵡';
                        break;
                    case 0x96B8:
                        *str++ = '椋';
                        break;
                    case 0x96B9:
                        *str++ = '婿';
                        break;
                    case 0x96BA:
                        *str++ = '娘';
                        break;
                    case 0x96BB:
                        *str++ = '冥';
                        break;
                    case 0x96BC:
                        *str++ = '名';
                        break;
                    case 0x96BD:
                        *str++ = '命';
                        break;
                    case 0x96BE:
                        *str++ = '明';
                        break;
                    case 0x96BF:
                        *str++ = '盟';
                        break;
                    case 0x96C0:
                        *str++ = '迷';
                        break;
                    case 0x96C1:
                        *str++ = '銘';
                        break;
                    case 0x96C2:
                        *str++ = '鳴';
                        break;
                    case 0x96C3:
                        *str++ = '姪';
                        break;
                    case 0x96C4:
                        *str++ = '牝';
                        break;
                    case 0x96C5:
                        *str++ = '滅';
                        break;
                    case 0x96C6:
                        *str++ = '免';
                        break;
                    case 0x96C7:
                        *str++ = '棉';
                        break;
                    case 0x96C8:
                        *str++ = '綿';
                        break;
                    case 0x96C9:
                        *str++ = '緬';
                        break;
                    case 0x96CA:
                        *str++ = '面';
                        break;
                    case 0x96CB:
                        *str++ = '麺';
                        break;
                    case 0x96CC:
                        *str++ = '摸';
                        break;
                    case 0x96CD:
                        *str++ = '模';
                        break;
                    case 0x96CE:
                        *str++ = '茂';
                        break;
                    case 0x96CF:
                        *str++ = '妄';
                        break;
                    case 0x96D0:
                        *str++ = '孟';
                        break;
                    case 0x96D1:
                        *str++ = '毛';
                        break;
                    case 0x96D2:
                        *str++ = '猛';
                        break;
                    case 0x96D3:
                        *str++ = '盲';
                        break;
                    case 0x96D4:
                        *str++ = '網';
                        break;
                    case 0x96D5:
                        *str++ = '耗';
                        break;
                    case 0x96D6:
                        *str++ = '蒙';
                        break;
                    case 0x96D7:
                        *str++ = '儲';
                        break;
                    case 0x96D8:
                        *str++ = '木';
                        break;
                    case 0x96D9:
                        *str++ = '黙';
                        break;
                    case 0x96DA:
                        *str++ = '目';
                        break;
                    case 0x96DB:
                        *str++ = '杢';
                        break;
                    case 0x96DC:
                        *str++ = '勿';
                        break;
                    case 0x96DD:
                        *str++ = '餅';
                        break;
                    case 0x96DE:
                        *str++ = '尤';
                        break;
                    case 0x96DF:
                        *str++ = '戻';
                        break;
                    case 0x96E0:
                        *str++ = '籾';
                        break;
                    case 0x96E1:
                        *str++ = '貰';
                        break;
                    case 0x96E2:
                        *str++ = '問';
                        break;
                    case 0x96E3:
                        *str++ = '悶';
                        break;
                    case 0x96E4:
                        *str++ = '紋';
                        break;
                    case 0x96E5:
                        *str++ = '門';
                        break;
                    case 0x96E6:
                        *str++ = '匁';
                        break;
                    case 0x96E7:
                        *str++ = '也';
                        break;
                    case 0x96E8:
                        *str++ = '冶';
                        break;
                    case 0x96E9:
                        *str++ = '夜';
                        break;
                    case 0x96EA:
                        *str++ = '爺';
                        break;
                    case 0x96EB:
                        *str++ = '耶';
                        break;
                    case 0x96EC:
                        *str++ = '野';
                        break;
                    case 0x96ED:
                        *str++ = '弥';
                        break;
                    case 0x96EE:
                        *str++ = '矢';
                        break;
                    case 0x96EF:
                        *str++ = '厄';
                        break;
                    case 0x96F0:
                        *str++ = '役';
                        break;
                    case 0x96F1:
                        *str++ = '約';
                        break;
                    case 0x96F2:
                        *str++ = '薬';
                        break;
                    case 0x96F3:
                        *str++ = '訳';
                        break;
                    case 0x96F4:
                        *str++ = '躍';
                        break;
                    case 0x96F5:
                        *str++ = '靖';
                        break;
                    case 0x96F6:
                        *str++ = '柳';
                        break;
                    case 0x96F7:
                        *str++ = '薮';
                        break;
                    case 0x96F8:
                        *str++ = '鑓';
                        break;
                    case 0x96F9:
                        *str++ = '愉';
                        break;
                    case 0x96FA:
                        *str++ = '愈';
                        break;
                    case 0x96FB:
                        *str++ = '油';
                        break;
                    case 0x96FC:
                        *str++ = '癒';
                        break;
                    case 0x9740:
                        *str++ = '諭';
                        break;
                    case 0x9741:
                        *str++ = '輸';
                        break;
                    case 0x9742:
                        *str++ = '唯';
                        break;
                    case 0x9743:
                        *str++ = '佑';
                        break;
                    case 0x9744:
                        *str++ = '優';
                        break;
                    case 0x9745:
                        *str++ = '勇';
                        break;
                    case 0x9746:
                        *str++ = '友';
                        break;
                    case 0x9747:
                        *str++ = '宥';
                        break;
                    case 0x9748:
                        *str++ = '幽';
                        break;
                    case 0x9749:
                        *str++ = '悠';
                        break;
                    case 0x974A:
                        *str++ = '憂';
                        break;
                    case 0x974B:
                        *str++ = '揖';
                        break;
                    case 0x974C:
                        *str++ = '有';
                        break;
                    case 0x974D:
                        *str++ = '柚';
                        break;
                    case 0x974E:
                        *str++ = '湧';
                        break;
                    case 0x974F:
                        *str++ = '涌';
                        break;
                    case 0x9750:
                        *str++ = '猶';
                        break;
                    case 0x9751:
                        *str++ = '猷';
                        break;
                    case 0x9752:
                        *str++ = '由';
                        break;
                    case 0x9753:
                        *str++ = '祐';
                        break;
                    case 0x9754:
                        *str++ = '裕';
                        break;
                    case 0x9755:
                        *str++ = '誘';
                        break;
                    case 0x9756:
                        *str++ = '遊';
                        break;
                    case 0x9757:
                        *str++ = '邑';
                        break;
                    case 0x9758:
                        *str++ = '郵';
                        break;
                    case 0x9759:
                        *str++ = '雄';
                        break;
                    case 0x975A:
                        *str++ = '融';
                        break;
                    case 0x975B:
                        *str++ = '夕';
                        break;
                    case 0x975C:
                        *str++ = '予';
                        break;
                    case 0x975D:
                        *str++ = '余';
                        break;
                    case 0x975E:
                        *str++ = '与';
                        break;
                    case 0x975F:
                        *str++ = '誉';
                        break;
                    case 0x9760:
                        *str++ = '輿';
                        break;
                    case 0x9761:
                        *str++ = '預';
                        break;
                    case 0x9762:
                        *str++ = '傭';
                        break;
                    case 0x9763:
                        *str++ = '幼';
                        break;
                    case 0x9764:
                        *str++ = '妖';
                        break;
                    case 0x9765:
                        *str++ = '容';
                        break;
                    case 0x9766:
                        *str++ = '庸';
                        break;
                    case 0x9767:
                        *str++ = '揚';
                        break;
                    case 0x9768:
                        *str++ = '揺';
                        break;
                    case 0x9769:
                        *str++ = '擁';
                        break;
                    case 0x976A:
                        *str++ = '曜';
                        break;
                    case 0x976B:
                        *str++ = '楊';
                        break;
                    case 0x976C:
                        *str++ = '様';
                        break;
                    case 0x976D:
                        *str++ = '洋';
                        break;
                    case 0x976E:
                        *str++ = '溶';
                        break;
                    case 0x976F:
                        *str++ = '熔';
                        break;
                    case 0x9770:
                        *str++ = '用';
                        break;
                    case 0x9771:
                        *str++ = '窯';
                        break;
                    case 0x9772:
                        *str++ = '羊';
                        break;
                    case 0x9773:
                        *str++ = '耀';
                        break;
                    case 0x9774:
                        *str++ = '葉';
                        break;
                    case 0x9775:
                        *str++ = '蓉';
                        break;
                    case 0x9776:
                        *str++ = '要';
                        break;
                    case 0x9777:
                        *str++ = '謡';
                        break;
                    case 0x9778:
                        *str++ = '踊';
                        break;
                    case 0x9779:
                        *str++ = '遥';
                        break;
                    case 0x977A:
                        *str++ = '陽';
                        break;
                    case 0x977B:
                        *str++ = '養';
                        break;
                    case 0x977C:
                        *str++ = '慾';
                        break;
                    case 0x977D:
                        *str++ = '抑';
                        break;
                    case 0x977E:
                        *str++ = '欲';
                        break;
                    case 0x9780:
                        *str++ = '沃';
                        break;
                    case 0x9781:
                        *str++ = '浴';
                        break;
                    case 0x9782:
                        *str++ = '翌';
                        break;
                    case 0x9783:
                        *str++ = '翼';
                        break;
                    case 0x9784:
                        *str++ = '淀';
                        break;
                    case 0x9785:
                        *str++ = '羅';
                        break;
                    case 0x9786:
                        *str++ = '螺';
                        break;
                    case 0x9787:
                        *str++ = '裸';
                        break;
                    case 0x9788:
                        *str++ = '来';
                        break;
                    case 0x9789:
                        *str++ = '莱';
                        break;
                    case 0x978A:
                        *str++ = '頼';
                        break;
                    case 0x978B:
                        *str++ = '雷';
                        break;
                    case 0x978C:
                        *str++ = '洛';
                        break;
                    case 0x978D:
                        *str++ = '絡';
                        break;
                    case 0x978E:
                        *str++ = '落';
                        break;
                    case 0x978F:
                        *str++ = '酪';
                        break;
                    case 0x9790:
                        *str++ = '乱';
                        break;
                    case 0x9791:
                        *str++ = '卵';
                        break;
                    case 0x9792:
                        *str++ = '嵐';
                        break;
                    case 0x9793:
                        *str++ = '欄';
                        break;
                    case 0x9794:
                        *str++ = '濫';
                        break;
                    case 0x9795:
                        *str++ = '藍';
                        break;
                    case 0x9796:
                        *str++ = '蘭';
                        break;
                    case 0x9797:
                        *str++ = '覧';
                        break;
                    case 0x9798:
                        *str++ = '利';
                        break;
                    case 0x9799:
                        *str++ = '吏';
                        break;
                    case 0x979A:
                        *str++ = '履';
                        break;
                    case 0x979B:
                        *str++ = '李';
                        break;
                    case 0x979C:
                        *str++ = '梨';
                        break;
                    case 0x979D:
                        *str++ = '理';
                        break;
                    case 0x979E:
                        *str++ = '璃';
                        break;
                    case 0x979F:
                        *str++ = '痢';
                        break;
                    case 0x97A0:
                        *str++ = '裏';
                        break;
                    case 0x97A1:
                        *str++ = '裡';
                        break;
                    case 0x97A2:
                        *str++ = '里';
                        break;
                    case 0x97A3:
                        *str++ = '離';
                        break;
                    case 0x97A4:
                        *str++ = '陸';
                        break;
                    case 0x97A5:
                        *str++ = '律';
                        break;
                    case 0x97A6:
                        *str++ = '率';
                        break;
                    case 0x97A7:
                        *str++ = '立';
                        break;
                    case 0x97A8:
                        *str++ = '葎';
                        break;
                    case 0x97A9:
                        *str++ = '掠';
                        break;
                    case 0x97AA:
                        *str++ = '略';
                        break;
                    case 0x97AB:
                        *str++ = '劉';
                        break;
                    case 0x97AC:
                        *str++ = '流';
                        break;
                    case 0x97AD:
                        *str++ = '溜';
                        break;
                    case 0x97AE:
                        *str++ = '琉';
                        break;
                    case 0x97AF:
                        *str++ = '留';
                        break;
                    case 0x97B0:
                        *str++ = '硫';
                        break;
                    case 0x97B1:
                        *str++ = '粒';
                        break;
                    case 0x97B2:
                        *str++ = '隆';
                        break;
                    case 0x97B3:
                        *str++ = '竜';
                        break;
                    case 0x97B4:
                        *str++ = '龍';
                        break;
                    case 0x97B5:
                        *str++ = '侶';
                        break;
                    case 0x97B6:
                        *str++ = '慮';
                        break;
                    case 0x97B7:
                        *str++ = '旅';
                        break;
                    case 0x97B8:
                        *str++ = '虜';
                        break;
                    case 0x97B9:
                        *str++ = '了';
                        break;
                    case 0x97BA:
                        *str++ = '亮';
                        break;
                    case 0x97BB:
                        *str++ = '僚';
                        break;
                    case 0x97BC:
                        *str++ = '両';
                        break;
                    case 0x97BD:
                        *str++ = '凌';
                        break;
                    case 0x97BE:
                        *str++ = '寮';
                        break;
                    case 0x97BF:
                        *str++ = '料';
                        break;
                    case 0x97C0:
                        *str++ = '梁';
                        break;
                    case 0x97C1:
                        *str++ = '涼';
                        break;
                    case 0x97C2:
                        *str++ = '猟';
                        break;
                    case 0x97C3:
                        *str++ = '療';
                        break;
                    case 0x97C4:
                        *str++ = '瞭';
                        break;
                    case 0x97C5:
                        *str++ = '稜';
                        break;
                    case 0x97C6:
                        *str++ = '糧';
                        break;
                    case 0x97C7:
                        *str++ = '良';
                        break;
                    case 0x97C8:
                        *str++ = '諒';
                        break;
                    case 0x97C9:
                        *str++ = '遼';
                        break;
                    case 0x97CA:
                        *str++ = '量';
                        break;
                    case 0x97CB:
                        *str++ = '陵';
                        break;
                    case 0x97CC:
                        *str++ = '領';
                        break;
                    case 0x97CD:
                        *str++ = '力';
                        break;
                    case 0x97CE:
                        *str++ = '緑';
                        break;
                    case 0x97CF:
                        *str++ = '倫';
                        break;
                    case 0x97D0:
                        *str++ = '厘';
                        break;
                    case 0x97D1:
                        *str++ = '林';
                        break;
                    case 0x97D2:
                        *str++ = '淋';
                        break;
                    case 0x97D3:
                        *str++ = '燐';
                        break;
                    case 0x97D4:
                        *str++ = '琳';
                        break;
                    case 0x97D5:
                        *str++ = '臨';
                        break;
                    case 0x97D6:
                        *str++ = '輪';
                        break;
                    case 0x97D7:
                        *str++ = '隣';
                        break;
                    case 0x97D8:
                        *str++ = '鱗';
                        break;
                    case 0x97D9:
                        *str++ = '麟';
                        break;
                    case 0x97DA:
                        *str++ = '瑠';
                        break;
                    case 0x97DB:
                        *str++ = '塁';
                        break;
                    case 0x97DC:
                        *str++ = '涙';
                        break;
                    case 0x97DD:
                        *str++ = '累';
                        break;
                    case 0x97DE:
                        *str++ = '類';
                        break;
                    case 0x97DF:
                        *str++ = '令';
                        break;
                    case 0x97E0:
                        *str++ = '伶';
                        break;
                    case 0x97E1:
                        *str++ = '例';
                        break;
                    case 0x97E2:
                        *str++ = '冷';
                        break;
                    case 0x97E3:
                        *str++ = '励';
                        break;
                    case 0x97E4:
                        *str++ = '嶺';
                        break;
                    case 0x97E5:
                        *str++ = '怜';
                        break;
                    case 0x97E6:
                        *str++ = '玲';
                        break;
                    case 0x97E7:
                        *str++ = '礼';
                        break;
                    case 0x97E8:
                        *str++ = '苓';
                        break;
                    case 0x97E9:
                        *str++ = '鈴';
                        break;
                    case 0x97EA:
                        *str++ = '隷';
                        break;
                    case 0x97EB:
                        *str++ = '零';
                        break;
                    case 0x97EC:
                        *str++ = '霊';
                        break;
                    case 0x97ED:
                        *str++ = '麗';
                        break;
                    case 0x97EE:
                        *str++ = '齢';
                        break;
                    case 0x97EF:
                        *str++ = '暦';
                        break;
                    case 0x97F0:
                        *str++ = '歴';
                        break;
                    case 0x97F1:
                        *str++ = '列';
                        break;
                    case 0x97F2:
                        *str++ = '劣';
                        break;
                    case 0x97F3:
                        *str++ = '烈';
                        break;
                    case 0x97F4:
                        *str++ = '裂';
                        break;
                    case 0x97F5:
                        *str++ = '廉';
                        break;
                    case 0x97F6:
                        *str++ = '恋';
                        break;
                    case 0x97F7:
                        *str++ = '憐';
                        break;
                    case 0x97F8:
                        *str++ = '漣';
                        break;
                    case 0x97F9:
                        *str++ = '煉';
                        break;
                    case 0x97FA:
                        *str++ = '簾';
                        break;
                    case 0x97FB:
                        *str++ = '練';
                        break;
                    case 0x97FC:
                        *str++ = '聯';
                        break;
                    case 0x9840:
                        *str++ = '蓮';
                        break;
                    case 0x9841:
                        *str++ = '連';
                        break;
                    case 0x9842:
                        *str++ = '錬';
                        break;
                    case 0x9843:
                        *str++ = '呂';
                        break;
                    case 0x9844:
                        *str++ = '魯';
                        break;
                    case 0x9845:
                        *str++ = '櫓';
                        break;
                    case 0x9846:
                        *str++ = '炉';
                        break;
                    case 0x9847:
                        *str++ = '賂';
                        break;
                    case 0x9848:
                        *str++ = '路';
                        break;
                    case 0x9849:
                        *str++ = '露';
                        break;
                    case 0x984A:
                        *str++ = '労';
                        break;
                    case 0x984B:
                        *str++ = '婁';
                        break;
                    case 0x984C:
                        *str++ = '廊';
                        break;
                    case 0x984D:
                        *str++ = '弄';
                        break;
                    case 0x984E:
                        *str++ = '朗';
                        break;
                    case 0x984F:
                        *str++ = '楼';
                        break;
                    case 0x9850:
                        *str++ = '榔';
                        break;
                    case 0x9851:
                        *str++ = '浪';
                        break;
                    case 0x9852:
                        *str++ = '漏';
                        break;
                    case 0x9853:
                        *str++ = '牢';
                        break;
                    case 0x9854:
                        *str++ = '狼';
                        break;
                    case 0x9855:
                        *str++ = '篭';
                        break;
                    case 0x9856:
                        *str++ = '老';
                        break;
                    case 0x9857:
                        *str++ = '聾';
                        break;
                    case 0x9858:
                        *str++ = '蝋';
                        break;
                    case 0x9859:
                        *str++ = '郎';
                        break;
                    case 0x985A:
                        *str++ = '六';
                        break;
                    case 0x985B:
                        *str++ = '麓';
                        break;
                    case 0x985C:
                        *str++ = '禄';
                        break;
                    case 0x985D:
                        *str++ = '肋';
                        break;
                    case 0x985E:
                        *str++ = '録';
                        break;
                    case 0x985F:
                        *str++ = '論';
                        break;
                    case 0x9860:
                        *str++ = '倭';
                        break;
                    case 0x9861:
                        *str++ = '和';
                        break;
                    case 0x9862:
                        *str++ = '話';
                        break;
                    case 0x9863:
                        *str++ = '歪';
                        break;
                    case 0x9864:
                        *str++ = '賄';
                        break;
                    case 0x9865:
                        *str++ = '脇';
                        break;
                    case 0x9866:
                        *str++ = '惑';
                        break;
                    case 0x9867:
                        *str++ = '枠';
                        break;
                    case 0x9868:
                        *str++ = '鷲';
                        break;
                    case 0x9869:
                        *str++ = '亙';
                        break;
                    case 0x986A:
                        *str++ = '亘';
                        break;
                    case 0x986B:
                        *str++ = '鰐';
                        break;
                    case 0x986C:
                        *str++ = '詫';
                        break;
                    case 0x986D:
                        *str++ = '藁';
                        break;
                    case 0x986E:
                        *str++ = '蕨';
                        break;
                    case 0x986F:
                        *str++ = '椀';
                        break;
                    case 0x9870:
                        *str++ = '湾';
                        break;
                    case 0x9871:
                        *str++ = '碗';
                        break;
                    case 0x9872:
                        *str++ = '腕';
                        break;
                }
            }
        }
    }
}