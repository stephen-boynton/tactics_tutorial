using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InfoEventArgs<T> : EventArgs {
  public T info;

  public InfoEventArgs () {
    info = default (T);
  }

  public InfoEventArgs (T info) {
    this.info = info;
  }
}