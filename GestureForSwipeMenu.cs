// Copyright (c) identiv, Inc - All Rights Reserved
// Unauthorized copying of this file, via any medium is strictly prohibited
// Proprietary and confidential

using System;
using Android.Views;
using Android.Content;
using Android.Widget;
using Android.Views.Animations;
using Android.Util;

namespace AndroidGesture {

  public class GestureForSwipeMenu : GestureDetector.SimpleOnGestureListener {

    private const int SWIPE_THRESHOLD = 100;
    private const int SWIPE_VELOCITY_THRESHOLD = 100;
    ListView menuListView;


    public GestureForSwipeMenu (ListView listView) {
      menuListView = listView;
    }


    /// <summary>
    /// Raises the down event.
    /// </summary>
    /// <param name="e">E.</param>
    public override Boolean OnDown (MotionEvent e) {
      return true;
    } // OnDown()


    /// <summary>
    /// Raises the fling event.
    /// </summary>
    /// <param name="e1">E1.</param>
    /// <param name="e2">E2.</param>
    /// <param name="velocityX">Velocity x.</param>
    /// <param name="velocityY">Velocity y.</param>
    public virtual Boolean OnFling (MotionEvent e1, MotionEvent e2, float velocityX, float velocityY) {
      Boolean result = false;
      try {
        float diffY = e2.GetY() - e1.GetY();
        float diffX = e2.GetX() - e1.GetX();
        if (Math.Abs(diffX) > Math.Abs(diffY)) {
          if (Math.Abs(diffX) > SWIPE_THRESHOLD && Math.Abs(velocityX) > SWIPE_VELOCITY_THRESHOLD) {
            if (diffX > 0) {
             onSwipeRight();
                if (menuListView.IsShown) { 
                  menuListView.Animation = new  TranslateAnimation(0f, -menuListView.MeasuredWidth, 0f, 0f);
                  menuListView.Animation.Duration = 300;
                  menuListView.Visibility = ViewStates.Gone;  
                } else {  
                  menuListView.Visibility = ViewStates.Visible; 
                  menuListView.RequestFocus(); 
                  menuListView.Animation = new  TranslateAnimation(-menuListView.MeasuredWidth, 0f, 0f, 0f);//starting edge of layout 
                  menuListView.Animation.Duration = 300;  
                }
            } else {
              onSwipeLeft();
            }
          }
          result = true;
        } 
        else if (Math.Abs(diffY) > SWIPE_THRESHOLD && Math.Abs(velocityY) > SWIPE_VELOCITY_THRESHOLD) {
          if (diffY > 0) {
            onSwipeBottom();
          } else {
            onSwipeTop();
          }
        }
        result = true;

      } catch (Exception e) {
      }
      return result;
    } // OnFling()

    public void onSwipeRight() {
      Log.Debug(TAG, "Right");

      if (menuListView != null) {
        if (menuListView.IsShown) { 
          menuListView.Animation = new  TranslateAnimation(0f, -menuListView.MeasuredWidth, 0f, 0f);
          menuListView.Animation.Duration = 300;
          menuListView.Visibility = ViewStates.Gone;  
        } else {  
          menuListView.Visibility = ViewStates.Visible; 
          menuListView.RequestFocus(); 
          menuListView.Animation = new  TranslateAnimation(-menuListView.MeasuredWidth, 0f, 0f, 0f);//starting edge of layout 
          menuListView.Animation.Duration = 300;  
        }
      }
    }
    private String TAG="TranslatorSwipeTouch";


    public void onSwipeLeft()
    {
      Log.Debug(TAG, "Left");
      //Toast.makeText(MyActivity.this, "top", Toast.LENGTH_SHORT).show();
    }

    public void onSwipeTop()
    {
      Log.Debug(TAG, "Top");
      //Toast.makeText(MyActivity.this, "top", Toast.LENGTH_SHORT).show();
    }

    public void onSwipeBottom()
    {
      Log.Debug(TAG, "Bottom");
      //Toast.makeText(MyActivity.this, "top", Toast.LENGTH_SHORT).show();
    }   


  }

}