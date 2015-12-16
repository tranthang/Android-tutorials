// Copyright (c) identiv, Inc - All Rights Reserved
// Unauthorized copying of this file, via any medium is strictly prohibited
// Proprietary and confidential

using System;
using Android.Views;
using Android.Graphics;
using Android.Widget;
using Android.Views.Animations;

namespace AndroidGesture {

  public class ItemTouchListener : Java.Lang.Object, View.IOnTouchListener {

    private int padding = 0;
    private int initialx = 0;
    private int currentx = 0;

    ListViewHolderClass viewHolder;
    ListView menuListView;
    GestureDetector gesture;

    public Boolean clgt {
      get;
      private set;
    }

    public ItemTouchListener (ListView lv) {
      menuListView = lv;
      gesture = new GestureDetector(lv.Context, new GestureForSwipeMenu(lv));
    }


    public Boolean OnTouch (View v, MotionEvent e) {
      gesture.OnTouchEvent(e);

//      if (e.Action == MotionEventActions.Down) {
//        padding = 0;
//        initialx = (int)e.GetX();
//        currentx = (int)e.GetX();
//        viewHolder = ((ListViewHolderClass)v.Tag);
//      }
//      if (e.Action == MotionEventActions.Move) {
//        currentx = (int)e.GetX();
//        padding = currentx - initialx;
//        clgt = false;
//        if(menuListView.IsShown) { 
//          menuListView.Animation = new  TranslateAnimation ( 0f , -menuListView.MeasuredWidth , 0f , 0f );
//          menuListView.Animation.Duration = 300;
//          menuListView.Visibility = ViewStates.Gone;  
//        } else {  
//          menuListView.Visibility =   ViewStates.Visible; 
//          menuListView.RequestFocus (); 
//          menuListView.Animation = new  TranslateAnimation ( -menuListView.MeasuredWidth, 0f , 0f , 0f );//starting edge of layout 
//          menuListView.Animation.Duration = 300;  
//        }
//      }
//      if (e.Action == MotionEventActions.Up || e.Action == MotionEventActions.Cancel) {
//        padding = 0;
//        initialx = 0;
//        currentx = 0;
//      }
//      if (viewHolder != null) {
//        if (padding == 0) {
//          v.SetBackgroundColor(Color.White);
//        }
//        if (padding > 75) {
//          //          viewHolder.(true);
//        }
//        if (padding < -75) {
//          //          viewHolder.setRunning(false);
//        }
//      }
      return true;
    }
  }


}