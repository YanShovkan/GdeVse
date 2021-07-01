	.arch	armv8-a
	.file	"compressed_assemblies.arm64-v8a.arm64-v8a.s"
	.include	"compressed_assemblies.arm64-v8a-data.inc"

	.section	.data.compressed_assembly_descriptors,"aw",@progbits
	.type	.L.compressed_assembly_descriptors, @object
	.p2align	3
.L.compressed_assembly_descriptors:
	/* 0: Firebase.dll */
	/* uncompressed_file_size */
	.word	86016
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_0

	/* 1: FormsViewGroup.dll */
	/* uncompressed_file_size */
	.word	15360
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_1

	/* 2: Java.Interop.dll */
	/* uncompressed_file_size */
	.word	164352
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_2

	/* 3: LiteDB.dll */
	/* uncompressed_file_size */
	.word	358912
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_3

	/* 4: Mono.Android.dll */
	/* uncompressed_file_size */
	.word	2234880
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_4

	/* 5: Mono.Security.dll */
	/* uncompressed_file_size */
	.word	121856
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_5

	/* 6: Newtonsoft.Json.dll */
	/* uncompressed_file_size */
	.word	684544
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_6

	/* 7: System.Core.dll */
	/* uncompressed_file_size */
	.word	550400
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_7

	/* 8: System.Data.dll */
	/* uncompressed_file_size */
	.word	747520
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_8

	/* 9: System.Drawing.Common.dll */
	/* uncompressed_file_size */
	.word	26112
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_9

	/* 10: System.Net.Http.dll */
	/* uncompressed_file_size */
	.word	230912
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_10

	/* 11: System.Numerics.dll */
	/* uncompressed_file_size */
	.word	38912
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_11

	/* 12: System.Reactive.dll */
	/* uncompressed_file_size */
	.word	1177088
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_12

	/* 13: System.Runtime.Serialization.dll */
	/* uncompressed_file_size */
	.word	419328
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_13

	/* 14: System.ServiceModel.Internals.dll */
	/* uncompressed_file_size */
	.word	55808
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_14

	/* 15: System.Xml.Linq.dll */
	/* uncompressed_file_size */
	.word	65024
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_15

	/* 16: System.Xml.dll */
	/* uncompressed_file_size */
	.word	1397760
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_16

	/* 17: System.dll */
	/* uncompressed_file_size */
	.word	883712
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_17

	/* 18: Xamarin.AndroidX.Activity.dll */
	/* uncompressed_file_size */
	.word	52224
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_18

	/* 19: Xamarin.AndroidX.AppCompat.AppCompatResources.dll */
	/* uncompressed_file_size */
	.word	16384
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_19

	/* 20: Xamarin.AndroidX.AppCompat.dll */
	/* uncompressed_file_size */
	.word	459776
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_20

	/* 21: Xamarin.AndroidX.Browser.dll */
	/* uncompressed_file_size */
	.word	56320
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_21

	/* 22: Xamarin.AndroidX.CardView.dll */
	/* uncompressed_file_size */
	.word	17408
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_22

	/* 23: Xamarin.AndroidX.CoordinatorLayout.dll */
	/* uncompressed_file_size */
	.word	78848
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_23

	/* 24: Xamarin.AndroidX.Core.dll */
	/* uncompressed_file_size */
	.word	586240
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_24

	/* 25: Xamarin.AndroidX.CustomView.dll */
	/* uncompressed_file_size */
	.word	8704
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_25

	/* 26: Xamarin.AndroidX.DrawerLayout.dll */
	/* uncompressed_file_size */
	.word	43520
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_26

	/* 27: Xamarin.AndroidX.Fragment.dll */
	/* uncompressed_file_size */
	.word	172544
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_27

	/* 28: Xamarin.AndroidX.Legacy.Support.Core.UI.dll */
	/* uncompressed_file_size */
	.word	15872
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_28

	/* 29: Xamarin.AndroidX.Lifecycle.Common.dll */
	/* uncompressed_file_size */
	.word	15360
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_29

	/* 30: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll */
	/* uncompressed_file_size */
	.word	15872
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_30

	/* 31: Xamarin.AndroidX.Lifecycle.ViewModel.dll */
	/* uncompressed_file_size */
	.word	16896
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_31

	/* 32: Xamarin.AndroidX.Loader.dll */
	/* uncompressed_file_size */
	.word	36352
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_32

	/* 33: Xamarin.AndroidX.RecyclerView.dll */
	/* uncompressed_file_size */
	.word	424448
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_33

	/* 34: Xamarin.AndroidX.SavedState.dll */
	/* uncompressed_file_size */
	.word	12800
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_34

	/* 35: Xamarin.AndroidX.SwipeRefreshLayout.dll */
	/* uncompressed_file_size */
	.word	39936
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_35

	/* 36: Xamarin.AndroidX.ViewPager.dll */
	/* uncompressed_file_size */
	.word	57344
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_36

	/* 37: Xamarin.Auth.dll */
	/* uncompressed_file_size */
	.word	111616
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_37

	/* 38: Xamarin.Essentials.dll */
	/* uncompressed_file_size */
	.word	43520
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_38

	/* 39: Xamarin.Firebase.Auth.Interop.dll */
	/* uncompressed_file_size */
	.word	17408
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_39

	/* 40: Xamarin.Firebase.Auth.dll */
	/* uncompressed_file_size */
	.word	151552
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_40

	/* 41: Xamarin.Firebase.Common.dll */
	/* uncompressed_file_size */
	.word	36352
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_41

	/* 42: Xamarin.Forms.Core.dll */
	/* uncompressed_file_size */
	.word	1204224
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_42

	/* 43: Xamarin.Forms.Maps.Android.dll */
	/* uncompressed_file_size */
	.word	198656
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_43

	/* 44: Xamarin.Forms.Maps.dll */
	/* uncompressed_file_size */
	.word	24576
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_44

	/* 45: Xamarin.Forms.Platform.Android.dll */
	/* uncompressed_file_size */
	.word	858112
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_45

	/* 46: Xamarin.Forms.Platform.dll */
	/* uncompressed_file_size */
	.word	178176
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_46

	/* 47: Xamarin.Forms.Xaml.dll */
	/* uncompressed_file_size */
	.word	103424
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_47

	/* 48: Xamarin.Google.Android.Material.dll */
	/* uncompressed_file_size */
	.word	232960
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_48

	/* 49: Xamarin.Google.Guava.ListenableFuture.dll */
	/* uncompressed_file_size */
	.word	18072
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_49

	/* 50: Xamarin.GooglePlayServices.Auth.Base.dll */
	/* uncompressed_file_size */
	.word	16896
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_50

	/* 51: Xamarin.GooglePlayServices.Auth.dll */
	/* uncompressed_file_size */
	.word	40960
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_51

	/* 52: Xamarin.GooglePlayServices.Base.dll */
	/* uncompressed_file_size */
	.word	127488
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_52

	/* 53: Xamarin.GooglePlayServices.Basement.dll */
	/* uncompressed_file_size */
	.word	38912
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_53

	/* 54: Xamarin.GooglePlayServices.Maps.dll */
	/* uncompressed_file_size */
	.word	242176
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_54

	/* 55: Xamarin.GooglePlayServices.Tasks.dll */
	/* uncompressed_file_size */
	.word	49664
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_55

	/* 56: XamarinAppWhereAll.Android.dll */
	/* uncompressed_file_size */
	.word	380416
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_56

	/* 57: XamarinAppWhereAll.dll */
	/* uncompressed_file_size */
	.word	49152
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_57

	/* 58: mscorlib.dll */
	/* uncompressed_file_size */
	.word	2127360
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_58

	.size	.L.compressed_assembly_descriptors, 944
	.section	.data.compressed_assemblies,"aw",@progbits
	.type	compressed_assemblies, @object
	.p2align	3
	.global	compressed_assemblies
compressed_assemblies:
	/* count */
	.word	59
	/* descriptors */
	.zero	4
	.xword	.L.compressed_assembly_descriptors
	.size	compressed_assemblies, 16
