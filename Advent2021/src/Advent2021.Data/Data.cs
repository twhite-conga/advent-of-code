namespace Advent2021.Data;

public static class Data
{
    public const string RawDepthMeasurementData = @"191
192
201
205
206
203
188
189
199
206
224
230
233
232
260
257
258
259
251
233
236
237
238
241
242
243
250
259
251
255
263
265
266
259
265
260
267
270
271
284
286
301
302
304
309
333
335
342
350
349
342
343
345
346
331
332
317
324
328
327
332
320
340
341
344
353
361
372
376
387
397
433
431
432
436
435
449
460
474
476
483
490
487
488
495
500
511
531
537
525
503
506
515
517
518
517
514
516
521
515
516
517
526
514
490
487
484
482
474
476
480
479
474
482
480
481
483
484
482
481
477
478
482
483
494
517
520
517
510
497
481
519
522
524
528
530
543
542
543
531
529
528
526
499
521
526
518
533
535
538
542
572
573
574
548
550
559
567
569
570
571
570
587
592
600
620
630
627
652
659
656
663
661
666
681
687
702
714
715
711
714
722
719
723
721
720
731
724
726
732
735
736
739
745
739
747
745
758
755
754
755
756
757
758
759
760
763
799
800
810
825
826
829
841
848
852
855
858
856
874
894
897
892
925
932
935
931
953
971
967
953
957
941
950
952
923
922
933
938
943
944
964
952
935
913
901
902
903
904
901
909
910
909
929
930
929
924
916
904
897
905
908
899
898
903
907
924
915
919
911
915
916
926
931
933
965
967
968
979
981
997
1009
1012
1010
1011
1036
1035
1049
1050
1048
1053
1054
1055
1053
1046
1055
1069
1067
1062
1081
1079
1091
1093
1095
1093
1100
1091
1093
1107
1109
1105
1111
1121
1140
1141
1148
1149
1162
1166
1165
1163
1164
1165
1169
1182
1188
1186
1185
1165
1169
1176
1177
1179
1183
1182
1188
1191
1181
1183
1204
1203
1204
1206
1201
1215
1232
1234
1239
1243
1235
1239
1242
1238
1240
1241
1263
1259
1267
1257
1261
1265
1264
1261
1260
1262
1265
1263
1266
1262
1263
1268
1271
1282
1286
1287
1284
1280
1279
1280
1288
1289
1292
1287
1293
1301
1329
1343
1350
1347
1348
1354
1356
1359
1360
1363
1369
1366
1369
1370
1368
1373
1376
1385
1391
1400
1411
1415
1396
1398
1428
1433
1442
1444
1436
1467
1469
1470
1484
1485
1489
1498
1468
1469
1468
1465
1459
1460
1458
1459
1460
1462
1467
1479
1499
1501
1512
1515
1516
1519
1524
1538
1547
1558
1563
1573
1584
1592
1606
1632
1630
1637
1640
1633
1662
1677
1681
1679
1681
1683
1684
1704
1709
1705
1702
1701
1700
1707
1708
1717
1709
1718
1721
1738
1740
1746
1748
1750
1751
1757
1758
1765
1767
1749
1730
1732
1745
1751
1752
1750
1747
1746
1751
1756
1766
1767
1769
1767
1775
1806
1812
1808
1809
1845
1846
1848
1860
1864
1866
1868
1874
1853
1852
1848
1835
1851
1850
1843
1842
1835
1862
1865
1859
1886
1887
1888
1900
1926
1942
1944
1945
1946
1945
1939
1946
1951
1946
1951
1957
1971
1985
1986
1987
1990
1991
1992
1991
1986
1989
1991
1998
1996
2002
2003
2007
2009
2010
1989
1991
1990
1991
2001
2016
2017
2026
2028
2039
2038
2053
2047
2052
2049
2050
2052
2057
2055
2053
2051
2042
2027
2036
2026
2040
2042
2046
2045
2050
2051
2072
2073
2075
2072
2078
2077
2082
2087
2074
2079
2074
2070
2071
2070
2074
2076
2077
2084
2086
2089
2102
2100
2102
2104
2110
2112
2093
2104
2107
2104
2130
2101
2103
2102
2103
2111
2116
2117
2122
2119
2126
2127
2128
2148
2159
2160
2157
2165
2173
2169
2170
2175
2161
2151
2163
2172
2209
2211
2209
2223
2222
2221
2220
2226
2228
2229
2226
2234
2214
2212
2216
2215
2220
2223
2228
2234
2233
2235
2233
2235
2264
2263
2262
2285
2287
2303
2286
2287
2279
2280
2285
2279
2281
2291
2295
2322
2323
2332
2337
2340
2343
2344
2370
2371
2370
2377
2385
2390
2389
2396
2401
2407
2410
2411
2412
2413
2415
2422
2419
2431
2439
2444
2447
2457
2443
2455
2466
2483
2471
2472
2481
2486
2490
2470
2471
2483
2481
2480
2490
2529
2541
2546
2547
2570
2574
2560
2558
2562
2561
2566
2565
2563
2569
2571
2582
2596
2594
2593
2594
2585
2566
2567
2550
2559
2551
2561
2542
2544
2553
2557
2561
2574
2577
2593
2601
2613
2621
2623
2628
2627
2648
2640
2639
2664
2649
2659
2663
2662
2664
2659
2660
2659
2675
2654
2655
2657
2656
2662
2669
2663
2652
2645
2656
2664
2660
2680
2684
2673
2678
2675
2662
2663
2666
2668
2681
2676
2687
2688
2689
2688
2689
2692
2693
2704
2703
2702
2701
2707
2710
2711
2713
2712
2687
2697
2698
2699
2733
2731
2738
2739
2740
2746
2741
2744
2741
2746
2744
2731
2733
2740
2741
2745
2747
2748
2765
2774
2787
2789
2790
2794
2797
2778
2788
2790
2789
2784
2788
2789
2807
2826
2842
2835
2834
2837
2846
2847
2849
2866
2868
2880
2881
2885
2892
2893
2895
2896
2905
2907
2914
2917
2915
2910
2914
2916
2917
2926
2927
2946
2961
2962
2952
2954
2960
2972
2976
2978
2999
3007
3009
2998
3001
3021
3017
3011
3013
3010
3007
3019
3020
3037
3038
3037
3041
3046
3060
3064
3066
3056
3059
3058
3049
3056
3063
3065
3055
3056
3055
3054
3067
3066
3071
3075
3057
3056
3057
3070
3082
3107
3109
3107
3102
3101
3103
3098
3096
3097
3093
3095
3097
3106
3124
3125
3128
3137
3145
3143
3146
3120
3122
3135
3129
3158
3159
3176
3212
3216
3220
3222
3225
3229
3235
3252
3247
3252
3256
3259
3270
3277
3286
3296
3311
3322
3324
3331
3363
3364
3376
3372
3373
3384
3392
3397
3393
3395
3407
3408
3409
3404
3409
3414
3422
3427
3426
3428
3410
3418
3416
3408
3406
3411
3412
3418
3427
3425
3413
3400
3399
3400
3393
3394
3395
3394
3393
3392
3389
3390
3394
3395
3402
3394
3395
3415
3405
3407
3432
3439
3437
3439
3458
3461
3469
3464
3463
3464
3453
3458
3452
3455
3456
3459
3464
3468
3471
3474
3476
3475
3477
3479
3481
3482
3492
3501
3506
3501
3497
3498
3501
3502
3496
3510
3513
3515
3533
3534
3545
3552
3561
3554
3561
3562
3563
3564
3553
3554
3558
3546
3547
3561
3563
3547
3570
3572
3579
3590
3604
3634
3627
3630
3629
3632
3598
3599
3619
3617
3630
3624
3625
3627
3636
3632
3633
3638
3642
3640
3621
3623
3620
3627
3625
3624
3616
3648
3630
3625
3628
3634
3629
3649
3651
3652
3653
3660
3672
3674
3684
3706
3707
3713
3708
3707
3697
3674
3670
3671
3670
3674
3676
3677
3674
3693
3691
3693
3694
3698
3662
3671
3664
3665
3666
3667
3665
3666
3667
3666
3667
3663
3662
3665
3659
3651
3657
3656
3663
3659
3669
3666
3652
3643
3635
3665
3673
3682
3681
3674
3673
3677
3674
3672
3674
3677
3685
3697
3696
3708
3704
3702
3705
3709
3740
3741
3740
3734
3738
3741
3743
3741
3723
3693
3703
3702
3712
3713
3705
3706
3703
3718
3749
3761
3760
3763
3765
3757
3733
3740
3736
3762
3761
3771
3764
3761
3763
3762
3756
3771
3753
3759
3789
3791
3792
3780
3787
3788
3786
3792
3793
3790
3794
3795
3794
3791
3801
3802
3811
3813
3815
3818
3824
3835
3837
3836
3838
3840
3841
3842
3840
3841
3843
3872
3879
3884
3871
3878
3896
3897
3896
3895
3893
3887
3882
3885
3887
3875
3876
3856
3859
3853
3831
3832
3831
3830
3814
3815
3799
3814
3811
3834
3845
3842
3847
3853
3854
3853
3851
3870
3869
3870
3868
3876
3874
3875
3872
3866
3874
3873
3857
3858
3857
3865
3874
3865
3876
3878
3881
3883
3884
3885
3887
3863
3862
3864
3867
3872
3875
3876
3884
3880
3891
3897
3898
3894
3891
3895
3893
3912
3913
3910
3916
3912
3917
3925
3937
3942
3941
3947
3952
3955
3952
3944
3945
3946
3960
3985
4012
4013
4014
4012
4032
4045
4029
4030
4048
4055
4054
4072
4073
4083
4085
4086
4091
4094
4097
4112
4090
4102
4108
4134
4147
4148
4149
4172
4175
4182
4176
4154
4170
4180
4179
4186
4187
4182
4170
4172
4178
4181
4193
4188
4193
4192
4202
4205
4207
4185
4183
4187
4189
4204
4207
4202
4204
4201
4214
4219
4216
4211
4199
4196
4195
4199
4200
4201
4192
4191
4195
4217
4205
4210
4218
4204
4207
4213
4214
4215
4233
4240
4253
4251
4253
4262
4266
4257
4261
4262
4271
4263
4262
4284
4288
4267
4276
4283
4284
4283
4284
4281
4278
4266
4261
4260
4276
4281
4283
4272
4297
4302
4301
4312
4311
4329
4346
4336
4347
4365
4364
4366
4370
4372
4365
4364
4367
4365
4366
4368
4369
4372
4379
4373
4391
4390
4393
4389
4370
4372
4375
4376
4378
4387
4388
4408
4419
4421
4414
4415
4413
4415
4419
4420
4405
4422
4421
4423
4435
4434
4439
4441
4443
4450
4446
4450
4452
4453
4454
4458
4462
4475
4492
4489
4494
4498
4497
4498
4499
4511
4515
4516
4529
4534
4538
4540
4537
4544
4561
4562
4563
4565
4569
4564
4569
4576
4580
4619
4618
4620
4633
4634
4613
4611
4614
4632
4618
4629
4631
4643
4640
4644
4628
4630
4632
4631
4648
4652
4651
4640
4637
4638
4641
4649
4654
4650
4648
4651
4650
4630
4631
4632
4628
4634
4633
4635
4641
4633
4632
4634
4646
4658
4654
4639
4658
4659
4664
4673
4679
4681
4687
4685
4719
4720
4721
4731
4741
4744
4727
4729
4735
4738
4748
4749
4750
4746
4753
4754
4762
4773
4774
4777
4783
4782
4793
4799
4805
4810
4813
4812
4824
4817
4815
4817
4816
4804
4809
4827
4820
4819
4849
4850
4851
4850
4862
4861
4873
4875
4878
4879
4882
4883
4878
4880
4893
4890
4891
4886
4889
4890
4904
4902
4925
4927
4923
4920
4915
4924
4896
4898
4891
4894
4898
4900
4901
4902
4912
4913
4911
4908
4917
4905
4908
4931
4934
4969
4973
4972
4982
4983
5001
5000
5004
5009
5007
5002
5000
4999
5000
5002
4991
4993
4997
4998
5000
5003
4998
4999
4996
5005
5004
4993
4994
4995
4996
5000
5004
5011
5013
5012
5002
4999
4979
4989
4992
5002
5004
5005
5004
5027
5026
5027
5031
5035
5037
5044
5050
5057
5062
5065
5062
5056
5058
5065
5073
5093
5092
5109
5110
5130
5137
5159
5172
5164
5194
5196
5197
5234
5233
5222
5225
5227
5231
5248
5249
5261
5254
5255
5256
5257
5254
5252
5253
5261
5279
5266
5267
5259
5283
5309
5332
5335
5336
5337
5336
5344
5349
5356
5386
5396
5403
5409
5410
5413
5415
5417
5431
5433
5436
5434
5436
5440
5450
5449
5461
5480
5482
5479
5481
5482
5494
5495
5494
5495
5498
5497
5510
5512
5508
5499
5509
5520
5540
5553
5554
5555
5568
5550
5540
5535
5564
5567
5575
5574
5586
5579
5580
5579
5577
5588
5592
5562
5568
5589
5595
5606
5607
5596
5608
5627
5635
5632
5631
5630
5629
5628
5626
5625
5629
5630
5629
5630
5633
5634
5639
5640
5660
5666
5660
5663
5662
5672
5671
5652
5650
5667
5666
5642
5643
5642
5640
5642
5644
5649
5650
5647
5648
5647
5651
5650
5651
5653
5646
5627
5636
5635
5623
5624
5625
5624
5633
5630
5622
5619
5616
5634
5635
5630
5664
5671
5673
5671
5683
5693
5699
5700
5701
5697
5693
5664
5665
5677
5670
5684
5653
5648
5646
5648
5645
5651
5650
5651
5652
5653
5654
5639
5648
5640
5657
5667
5685
5706
5697
5698
5702
5709
5705
5720
5723
5716
5712
5708
5707
5668
5665
5666
5667
5666
5670
5669
5670
5671
5675
5676
5682
5683
5673
5675
5666
5675
5677
5686
5693
5694
5676
5677
5678
5680
5689
5712
5714
5730
5729
5740
5743
5776
5777
5788
5787
5783
5791";

    public const string RawPlottedCourseData = @"forward 3
down 9
forward 5
up 1
forward 2
down 1
down 7
down 5
up 6
forward 3
down 6
forward 9
down 6
forward 2
down 4
forward 4
down 9
down 7
down 2
down 4
forward 3
forward 6
down 3
up 1
down 5
down 8
down 1
forward 9
forward 4
forward 3
down 3
down 6
down 3
up 2
down 3
down 9
down 1
down 9
up 8
down 1
down 9
forward 9
forward 2
down 1
forward 2
down 9
forward 9
up 7
forward 1
up 8
forward 7
forward 6
forward 2
down 8
forward 7
down 3
down 2
down 1
forward 2
down 6
forward 8
down 7
forward 9
down 7
down 9
forward 2
forward 2
up 3
down 4
down 8
forward 5
down 4
down 8
down 2
up 7
down 7
up 9
up 9
up 1
forward 2
up 4
forward 5
forward 9
forward 9
forward 3
down 6
up 3
down 1
forward 8
forward 2
down 7
forward 9
forward 1
forward 8
forward 8
down 2
down 6
forward 8
forward 8
forward 3
forward 4
down 3
up 3
forward 1
forward 4
down 1
down 4
down 2
down 3
forward 5
down 3
up 5
forward 9
down 8
up 6
down 6
up 7
up 7
forward 1
forward 7
down 1
up 3
down 1
forward 7
forward 1
forward 9
down 2
forward 9
down 3
down 5
forward 2
up 3
forward 5
forward 5
down 8
down 7
forward 6
down 2
down 5
up 4
up 5
down 6
forward 5
down 3
down 8
forward 7
down 5
down 5
down 9
down 9
down 2
down 7
up 4
forward 8
up 6
down 5
forward 1
up 2
down 6
up 8
up 7
down 6
forward 4
down 6
up 6
up 4
forward 5
forward 4
forward 6
down 3
down 7
down 9
forward 2
forward 6
down 3
forward 1
forward 2
forward 9
up 5
down 7
down 6
forward 2
forward 1
up 3
down 8
forward 9
down 7
forward 7
up 2
up 8
up 8
forward 7
forward 5
forward 9
down 7
down 7
forward 5
forward 4
forward 2
forward 8
up 3
up 7
forward 8
forward 6
forward 2
forward 6
up 3
up 1
forward 6
forward 9
down 1
forward 6
forward 4
up 6
forward 1
down 7
forward 7
up 5
down 5
down 3
forward 4
forward 6
up 6
forward 9
forward 2
down 7
forward 9
down 9
forward 2
up 1
down 4
forward 6
forward 4
down 6
forward 1
up 3
up 5
down 8
forward 2
up 7
down 5
down 2
down 6
forward 7
down 8
up 8
down 7
down 9
down 7
down 8
down 4
up 3
up 9
down 4
forward 7
down 5
up 8
down 3
forward 8
down 3
down 4
down 1
forward 5
down 4
down 8
up 7
forward 2
forward 8
down 1
down 3
forward 4
forward 5
forward 8
forward 1
down 1
down 9
up 8
forward 6
down 8
down 2
forward 9
down 5
down 8
up 8
up 5
forward 9
up 6
down 9
up 1
down 2
down 4
forward 9
forward 1
up 2
down 7
forward 9
down 9
down 6
down 9
down 8
forward 7
forward 6
forward 9
forward 9
forward 8
forward 5
up 2
forward 9
forward 2
down 1
down 1
down 5
down 1
down 7
up 2
up 7
forward 7
forward 8
down 2
down 2
down 3
up 8
up 8
up 3
forward 3
down 7
up 4
up 8
down 5
forward 4
forward 7
down 9
up 7
forward 8
forward 5
forward 8
forward 8
forward 6
forward 5
forward 2
down 3
up 2
forward 6
forward 5
down 9
down 2
down 7
down 2
forward 2
forward 6
forward 8
down 7
forward 4
down 3
down 5
forward 1
down 9
forward 5
down 4
forward 9
down 5
down 4
down 4
down 7
forward 9
down 3
down 5
down 6
down 4
forward 4
down 4
up 1
down 4
up 7
forward 4
forward 5
up 9
down 4
up 9
forward 9
down 8
down 1
up 7
down 4
up 4
forward 9
down 9
down 4
up 4
down 5
forward 2
up 4
down 3
forward 9
forward 8
down 2
forward 5
up 5
down 9
down 7
down 5
down 9
down 1
down 7
down 2
forward 4
up 7
forward 7
down 8
down 2
down 8
up 6
down 7
down 7
forward 3
up 3
forward 6
down 8
down 3
up 2
down 9
forward 3
down 9
down 6
up 8
forward 5
down 9
up 2
up 8
down 8
up 1
up 2
forward 5
up 3
down 7
forward 4
forward 2
up 1
forward 2
up 1
down 1
down 5
forward 6
up 2
down 7
down 8
down 9
up 9
down 2
up 2
forward 9
forward 6
forward 5
down 6
up 6
forward 6
forward 3
down 3
forward 2
forward 4
forward 1
down 9
forward 3
forward 2
down 5
up 2
forward 7
down 4
forward 5
down 4
forward 2
down 4
up 3
forward 6
forward 9
down 1
forward 2
up 8
forward 4
up 9
up 4
up 3
forward 5
down 7
forward 2
up 4
forward 7
down 8
forward 6
forward 4
up 5
down 4
down 6
down 3
forward 6
down 9
up 6
forward 3
down 4
forward 8
forward 1
down 3
down 4
up 4
forward 1
up 5
up 9
forward 4
up 9
forward 2
up 5
up 5
up 7
up 4
down 3
forward 8
forward 1
up 1
down 8
up 3
up 4
up 2
up 8
up 7
down 8
up 8
forward 9
down 8
up 5
forward 6
forward 4
down 8
down 9
down 4
down 6
forward 4
up 6
up 1
forward 7
up 4
down 6
up 3
down 4
forward 8
forward 4
up 2
down 3
up 3
up 9
down 4
forward 4
forward 5
forward 2
down 1
down 6
down 1
forward 6
down 2
forward 1
down 2
down 4
forward 1
down 8
up 2
down 5
forward 9
forward 4
down 9
forward 8
forward 2
forward 7
forward 1
forward 1
down 8
forward 2
forward 8
forward 7
forward 9
down 4
down 2
forward 1
forward 2
down 1
forward 1
forward 5
down 1
down 5
down 1
forward 2
up 9
forward 2
forward 4
down 9
up 7
down 1
up 4
forward 9
up 6
up 8
down 3
forward 9
up 6
down 1
forward 9
forward 3
up 5
forward 9
down 1
forward 5
up 5
down 1
up 4
forward 3
forward 1
up 4
forward 3
forward 9
down 2
forward 5
forward 4
forward 9
down 5
forward 8
forward 1
down 3
down 2
down 3
up 8
forward 3
forward 6
up 8
down 6
forward 8
forward 1
down 8
down 7
forward 8
down 2
forward 8
down 4
forward 1
down 1
up 6
forward 1
up 7
down 2
forward 5
up 9
down 5
forward 4
down 6
down 9
forward 8
up 2
up 7
forward 2
forward 5
up 9
down 4
forward 9
down 4
down 3
down 6
down 9
down 9
down 1
down 1
down 7
down 4
down 7
up 5
forward 6
down 9
forward 7
down 5
down 4
down 2
down 4
down 9
forward 1
down 9
down 8
forward 2
up 7
up 3
forward 9
forward 4
down 8
down 4
forward 2
down 8
up 3
forward 6
forward 4
down 2
up 9
down 5
up 8
up 6
up 3
down 2
forward 6
forward 4
forward 7
forward 2
down 5
down 2
forward 2
forward 6
down 5
down 4
forward 8
up 3
forward 7
down 1
forward 5
down 8
down 9
forward 5
down 7
forward 7
up 6
down 3
forward 1
down 2
down 9
down 2
down 1
forward 4
up 5
up 9
forward 1
down 5
forward 4
up 3
up 5
forward 7
forward 5
down 2
down 8
forward 5
down 7
up 8
down 5
down 6
forward 8
forward 9
down 8
up 3
down 8
down 2
forward 8
forward 8
forward 4
forward 9
up 7
up 1
down 5
down 8
down 5
forward 3
forward 2
down 8
down 3
down 2
down 5
forward 8
up 3
down 9
up 4
up 1
up 8
down 8
forward 5
down 2
forward 4
forward 1
down 7
forward 4
forward 5
up 2
down 6
up 9
forward 1
down 9
forward 4
down 7
down 9
up 9
forward 2
forward 7
down 7
forward 9
forward 1
forward 1
down 7
up 6
up 3
forward 2
forward 6
forward 9
forward 3
forward 4
forward 9
forward 9
forward 9
down 8
up 2
forward 7
down 8
down 3
up 8
down 8
forward 1
forward 9
forward 2
forward 3
down 8
forward 1
forward 4
down 9
down 4
up 7
forward 5
down 4
forward 5
down 2
forward 6
down 1
up 9
down 5
up 5
down 2
up 1
up 8
down 3
up 3
down 8
forward 4
forward 1
up 5
forward 1
down 5
up 5
forward 8
down 1
up 4
forward 9
forward 7
up 1
up 9
forward 7
forward 1
up 5
forward 6
down 2
up 5
down 4
down 6
down 3
forward 8
down 7
down 5
down 7
forward 1
down 7
up 5
down 4
down 4
down 4
forward 3
forward 4
up 6
forward 8
forward 2
up 1
forward 5
forward 6
forward 6
up 2
down 3
forward 3
up 8
forward 6
forward 5
up 2
up 5
down 6
down 8
down 1
forward 6
down 3
down 2
forward 4
down 4
down 7
forward 9
forward 4
forward 5
down 8
down 9
up 4
up 4
down 5
up 1
up 6
down 9
forward 9
forward 4
forward 9
forward 9
down 5
down 1
up 9
down 3
up 5
down 7
forward 6
forward 2
down 5
down 6
forward 7
forward 2
up 9
forward 6
down 7
up 4
forward 1
down 5
forward 2
forward 1
down 6
down 1
down 4
forward 8
forward 1
down 5
down 8
down 3
forward 4
down 2
forward 9
up 1
forward 8
down 4
down 3
down 1
forward 5
forward 9
down 3
forward 6
up 6
up 9
forward 8
forward 2
down 9
forward 3
down 4
down 5
down 4
forward 2
forward 6
down 9
down 5
forward 6
forward 3
forward 5
forward 6
forward 5
forward 1
up 4
up 1
down 2
up 6
down 5
down 1
forward 9
down 1
down 2
forward 6
up 2
down 4
up 3
forward 8
down 4
down 4
down 6
up 1
down 7
up 4
down 6
up 7
up 6
down 5
forward 3
forward 4
up 5
down 2
down 9
forward 9";
}
