[English Here]

# Endless Brick Breaker II
 Một phiên bản mới của game Endless Brick Breaker được tạo ra trước đó do việc đưa các file .meta vào danh sách gitignore dẫn tới hỏng dự án.
 
 Được lập trình bởi Qwekem482
 
 
 ## Cơ chế game
  - Game có 4 chỉ số chính:
     - Điểm số: Tính bằng công thức $Số Khối Đã Phá * Cấp Độ$.
     - Thời gian: Thời gian đã chơi, tính từ khi bắt đầu lượt chơi này.
     - Mạng: Số mạng còn lại.
     - Cấp độ: Cấp độ hiện tại.
  - Khi bắt đầu một lượt chơi sẽ có 4 mạng. Người chơi mất 1 mạng khi để toàn bộ bóng rơi ra ngoài.
  - Khi phá hết toàn bộ gạch, Gạch mới sẽ được tạo ra ngay lập tức một cách tự động. Ngoài ra, người chơi sẽ có thêm 2 mạng đồng thời tốc độ của bóng và rổ sẽ tăng.
  - Số lượng và vị trí của gạch là ngẫu nhiên. Mỗi lượt sẽ có ít nhất 30 và nhiều nhất 80 gạch.


## Điểm mới
 - Game hiện tại có giao diện (UI)
 - Game hiện tại có phiên bản Android.
 - Game có thể tự động căn chỉnh kích thước của các vật trong game cũng như UI để phù hợp với các tỉ lệ màn hình khác nhau.
 - Bỏ các nút đổi màu. Game tự động đổi màu một số vật trong game khi mất 1 mạng.
 - Các màu để thay đổi hiện tại chỉ dùng màu nhạt.
 - Tốc độ bóng tăng mỗi khi lên cấp. Công thức: $10 + 0.75\sqrt{3 * Cấp Độ} + Cấp Độ/40$
 - Tốc độ rổ tăng mỗi khi lên cấp. Công thức: $10 + 0.75\sqrt{4 * Cấp Độ} + Cấp Độ/30$

## Hạn chế còn tồn tại
 - Cơ chế điều khiển rổ hơi tệ.
 - Màn hình bắt đầu và kết thúc còn đơn điệu.
 - Ở một số tỷ lệ màn hình, hàng cao nhất ở khu vực tạo gạch thường trống.


## Hỗ Trợ
 ![Percentage](https://user-images.githubusercontent.com/80797630/216106474-3f61e883-1114-42af-acfd-2af312b6d185.png)

 - Dự án này được tạo ra bằng Unity Engine, lập trình bằng Visual Studio Code
 - Sprite được tạo bởi [Figma](https://www.figma.com/ "Figma") bởi Qwekem482.
 - UI được thiết kế bởi [Nemie](https://www.facebook.com/nemie1502 "Nemie")
 - Âm thanh từ Unity Asset Store: 
      - [Casual Game BGM #5](https://assetstore.unity.com/packages/audio/music/casual-game-bgm-5-135943) by [B.G.M](https://assetstore.unity.com/publishers/9381 "B.G.M")
      - [FREE Casual Game SFX Pack](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116) by [Dustyroom](https://assetstore.unity.com/publishers/16150 "Dustyroom")
 - Tựa game này được tạo ra nhờ sự hỗ trợ của ![4d4d4d](https://placehold.co/15x15/4d4d4d/4d4d4d.png) [Unity Forum](https://forum.unity.com/ "Unity Forum"), ![#f37700](https://placehold.co/15x15/f37700/f37700.png) [Stackoverflow](https://stackoverflow.com/ "Stackoverflow"), ![#00fff0](https://placehold.co/15x15/00fff0/00fff0.png) [noobtuts](https://noobtuts.com/unity/2d-arkanoid-game "noobtuts")
 
## Screenshot
![Screenshot_20230526-163622](https://github.com/Qwekem482/EndlessBrickBreaker/assets/80797630/d37c300a-ecf8-47bb-b504-049b170e0783)
![Screenshot_20230526-163630](https://github.com/Qwekem482/EndlessBrickBreaker/assets/80797630/779dfde7-1627-4b38-a037-4029b7d48eb4)
![Screenshot_20230526-163639](https://github.com/Qwekem482/EndlessBrickBreaker/assets/80797630/4c58c896-ce49-4ac8-8167-8c5cf3836b09)
![Screenshot_20230526-163654](https://github.com/Qwekem482/EndlessBrickBreaker/assets/80797630/b9a75bce-29f2-4114-99c2-f60dd1118673)
