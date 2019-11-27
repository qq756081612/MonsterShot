###1.Facade
外观模式，在接入PureMVC时，只需继承Facade类,Facade作为统一的对外接口,无需实现其余M/V/C核心类
一般地，实际的应用程序都有一个 Façade 子类，这个 Façade 类对象负责初始化 Controller（控制器），建立 Command 与 Notification 名之间的映射，并执行一个 Command 注册所有的 Model 和 View。

###2.INotifier
F/M/V/C都实现了INotifier接口，可以SendNotification

###3.Commond类功能
1.获取Proxy对象
2.SendNotification
3.Excute其他Commond
4.可被Notification触发

###4.Mediator类功能
当用 View 注册 Mediator 时，Mediator 的 listNotifications 方法会被调用，
以数组形式返回该 Mediator 对象所关心的所有 Notification。
之后，当系统其它角色发出同名的 Notification（通知）时，关心这个通知的
Mediator 都会调用 handleNotification 方法并将 Notification 以参数传递到
方法。

###5.Proxy类功能
1.操作数据
2.Proxy发送，但不接收Notification，否则耦合度太高 

###6.核心类之间关系
Command 与 Mediator 和 Proxy 交互，应避免 Mediator 与 Proxy 直接交互 ???
因为 Mediator 也会经常和 Proxy 交互，所以经常在 Mediator 的构造方法中取得
Proxy 实例的引用并保存在 Mediator 的属性中，这样避免频繁的获取 Proxy 实
例。