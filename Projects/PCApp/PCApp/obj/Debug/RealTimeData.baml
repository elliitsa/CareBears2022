   M S B A M L   `   `   `  ����@  <PCApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PCAppPCApp  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       PCApp.RealTimeData   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PCApp     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$	  wdw��5
   	   
������� � Title$ RealTimeData��5   	   $	��450��6   $	��800��6+   $	��450��67   $	��800��6G   .��5      �  � RowDefinitions 5   
   �� 5      $��50��6   $	��50* �6+   �� 5      $��50��6   $	��50* �6+   �� 5      $��50��6   $	��50* �6+   �� 5      $��50��6   $	��50* �6+   �� 5      $��50��6   $	��50* �6+   �� 5      $��50��6   $	��50* �6+   �� 5      $��50��6   $	��50* �6+   �� 5      $��50��6   $	��50* �6+    � ColumnDefinitions 5   
   �� 5      $��25��6   $	��25* �6-   �� 5      $	��250��6   $
��100* �6.   �� 5      $��25��6   $	��25* �6-   .+�5       �� -   5         ��Name$ 
heart_rate��5    5   $��1��6   $��0��6(    �� TextAlignment$ Center=�6I   $��20(�6`   ��6n   �� *+)dmodel_list[dmodel_list.Count].heart_rate+�� 5!      -   5        $ oxygen_level��5!   5   $��1��6   $��1��6(   $ Center=�6K   $��20(�6b   ��6p   �� *-+dmodel_list[dmodel_list.Count].oxygen_level+�� 5"   
   -   5        $
 gps1��5"   1   $��1��6   $��2��6$   $ Center=�6?   $��20(�6V   ��6d   �� *.,dmodel_list[dmodel_list.Count].gps_longitude+�� 5#   
   -   5        $
 gps2��5#   1   $��1��6   $��3��6$   $ Center=�6?   $��20(�6V   ��6d   �� *-+dmodel_list[dmodel_list.Count].gps_latitude+�� 5$   
   -   5        $ emerg��5$   1   $��1��6   $��4��6$   $ Center=�6@   $��20(�6W   ��6e   �� **(dmodel_list[dmodel_list.Count].emergency+�� 5%   
   -   5        $
 date��5%   1   $��1��6   $��5��6$   $ Center=�6?   $��20(�6V   ��6d   �� *%#dmodel_list[dmodel_list.Count].date+�� 5&   
   -   5        $
 time��5&   1   $��1��6   $��6��6$   $ Center=�6?   $��20(�6V   ��6d   �� *%#dmodel_list[dmodel_list.Count].time+�� 5'   
   -	   5        $ updateCount��5'   1   $��1��6   $��7��6$   $ Center=�6F   $
��Bold"�6]   $��Normal$�6p   $��20(�6�   ��6�   �� *count+�� 5*   
   -
   5         ��Name$ btnBack��5*   .   $��0��6   $��0��6!    !  MaterialDesignFlatMidBgButton#��[  6?   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5+      $��25��6J   $��65��6V   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5,      $��10(�6G   $
��Back��6U   6d   �� 5.   
   -   5        $ 	btnLogout��5.   .   $��2��6   $��0��6!   #��[  6A   $ Depth0=�5/      $��25��6J   $��65��6V   $ 10��50      $��10(�6G   $��Logout��6U   6f   51      52      