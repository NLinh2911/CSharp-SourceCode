# Dựng game con rắn bằng C# chạy trên terminal

## Mục tiêu: tạo ra 1 console game đơn giản
* Làm quen với ngôn ngữ C#
* Tạo biến, xử lý điều kiện, vòng lặp
* Các phương thức, thuộc tính của Console
* Thread trong C# để chạy 2 tác vụ song song

## Video 1: Cài đặt môi trường - ví dụ hello world

## Video 2: Làm quen với Console

* Bắt đầu chương trình: Console.Clear() hiển thị màn hình game
* Điều chỉnh kích thước màn hình game SetWindowSize(), SetBufferSize()
* Điều chỉnh màu sắc BackgroundColor(), ForegroundColor()
* Console.ReadKey() nhận keyboard input của người chơi
* In ra màn hình

### Mục tiêu: hiển thị game screen, lời chào, nhận key input, vẽ snake (size = 1)

## Video 3: Di chuyển snake theo arrow keys
* Point class cho tọa độ
* Console.ReadKey()
* Console.KeyAvailable, ConsoleKeyInfo, check key nào đc bấm
* Di chuyển, thay đổi tọa độ của snake 

## Video 4: Vẽ thêm đồ ăn
* Tạo biến, vẽ đồ ăn random
* Kiểm tra collision -> snake ăn đồ ăn -> tạo đồ ăn mới random
* Tăng điểm

## Video 5: Vẽ snake với List, xử lý khi di chuyển
* List<T>, Insert, RemoveAt
* 

## Video 6: Tăng kích thước snake khi ăn

## Video 7: Tính collision với tường và chính nó
* try/ catch
* if else

## Video 8: Tự dộng chạy với threading