   M S B A M L   `   `   `  ����@  <PCApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PCAppPCApp  5   	       PCApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PCApp     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
�������  � Title$  
MainWindow��5	   	   $	��450��5
   	   $	��800��6   $	��450��6"   $	��800��62    � 
ResizeMode$ CanResizeWithGrip=�6A   .��5      �  � RowDefinitions 5   
   �� 5      $��50��6   $	��50* �6+   �� 5      $��30��6   $	��10* �6+   �� 5      $��30��6   $	��35* �6+   �� 5      $��30��6   $	��20* �6+   �� 5      $��30��6   $	��40* �6+    � ColumnDefinitions 5   
   �� 5      $	��250��6   $
��100* �6.   �� 5      $	��250��6   $
��100* �6.   �� 5      $	��250��6   $
��100* �6.   .+�5   
   �� -   5         ��Name$ btnDatabaseData��5   /   $��2��6   $��0��6   
����� �
���   �$
��Bold"�6�   $��75��6�   $	��150��6�   $��Database data��6�   �� 5   
   -   5        $ btnRealtimeData��5   /   $��2��6   $��1��6   
����� �
���   �$
��Bold"�6�   $��75��6�   $	��150��6�   $��Real Time data��6�   �� 5   
   -   5        $ btnSDCardData��5   /   $��2��6   $��2��6   
����� �
���   �$
��Bold"�6�   $��75��6�   $	��150��6�   $��SD-Card data��6�   �� 5    
   $��1��6   $��1��6!   $
��Bold"�61   $��20(�6C   $!��Choose desired data please?��6Q   �� 5!   
   -   5        $ 	btnLogout��5!   .   $��3��6   $��0��6!    !  MaterialDesignFlatMidBgButton#��[  6A   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5"      $��25��6J   $��65��6V   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5#      $��10(�6G   $��Logout��6U   6f   5'      5(      