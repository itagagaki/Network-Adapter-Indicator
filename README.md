このWindowsアプリケーションは、現在VPNに接続しているかどうかを通知領域（システムトレイ）のアイコンで示します。
VPN接続しているかどうかは、'VPN'で始まる名前のネットワークアダプターが接続状態にあるかどうかというロジックで判定しています。
このチェックはネットワークアドレスまたはネットワーク接続状態が変わったときに行われます。
ネットワークアダプターの名前を変更しても、その時には再チェックは行われませんのでご注意ください。

アイコンファイル `Adapter_Up.ico` と `Adapter_Down.ico` は、あまり見栄えがいいものではないので、どうぞお好きなように入れ替えてください。
どなたか素敵なアイコンを寄贈していただけると嬉しいです。

This Windows application shows you if you are currently connected to a VPN with an icon in the notification area (system tray).
(Please excuse the slight difference between the name of the application and its purpose).

The logic behind whether a VPN connection is active or not is based on whether a network adapter with a name beginning with 'VPN' is connected.
This check is performed whenever the network address or network connection state changes.
Note that if the name of the network adapter is changed, the check will not be performed again at that time.

The icon files `Adapter_Up.ico` and `Adapter_Down.ico` are not very nice looking, so feel free to replace them as you wish.
I would be grateful if someone would donate a nice icon set.
