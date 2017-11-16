﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReactiveProgrammingUnitTest
{
  [TestClass]
  public class ProducerConsumerUnitTest
  {
    [TestMethod]
    public async Task CheckWheterProducesWell()
    {
      Assert.Inconclusive("From time to time hangs up ");
      TimeSpan period = TimeSpan.FromMilliseconds(100);
      int counter = 1;
      List<int> expectedProducts = new List<int> { 1, 2, 3 };
      IObservable<bool> consumerMock = Observable
          .Interval(period)
          .Select(_ => true)
          .Take(3);
      Producer<int> producer = new Producer<int>(() => counter++, period, 2);
      consumerMock.Subscribe(producer);
      IList<int> products = await producer.Take(3).ToList();
      Assert.IsTrue(expectedProducts.SequenceEqual(products));
    }
  }
}
