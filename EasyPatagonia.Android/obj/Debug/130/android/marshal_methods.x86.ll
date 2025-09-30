; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [222 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 49
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 84
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 77
	i32 101534019, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 65
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 65
	i32 134690465, ; 5: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 92
	i32 165246403, ; 6: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 26
	i32 182336117, ; 7: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 67
	i32 209399409, ; 8: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 24
	i32 212497893, ; 9: Xamarin.Forms.Maps.Android => 0xcaa75e5 => 78
	i32 230216969, ; 10: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 43
	i32 232815796, ; 11: System.Web.Services => 0xde07cb4 => 107
	i32 261689757, ; 12: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 29
	i32 278686392, ; 13: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 47
	i32 280482487, ; 14: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 41
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 16
	i32 319314094, ; 16: Xamarin.Forms.Maps => 0x130858ae => 79
	i32 321597661, ; 17: System.Numerics => 0x132b30dd => 11
	i32 342366114, ; 18: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 45
	i32 441335492, ; 19: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 28
	i32 442521989, ; 20: Xamarin.Essentials => 0x1a605985 => 76
	i32 450948140, ; 21: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 40
	i32 465846621, ; 22: mscorlib => 0x1bc4415d => 8
	i32 469710990, ; 23: System.dll => 0x1bff388e => 10
	i32 476646585, ; 24: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 41
	i32 486930444, ; 25: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 53
	i32 498788369, ; 26: System.ObjectModel => 0x1dbae811 => 109
	i32 526420162, ; 27: System.Transactions.dll => 0x1f6088c2 => 101
	i32 527452488, ; 28: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 92
	i32 576044450, ; 29: XamarinVideoPlayer => 0x2255bda2 => 96
	i32 605376203, ; 30: System.IO.Compression.FileSystem => 0x24154ecb => 105
	i32 606499775, ; 31: EasyPatagonia.dll => 0x242673bf => 4
	i32 627609679, ; 32: Xamarin.AndroidX.CustomView => 0x2568904f => 34
	i32 639843206, ; 33: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 39
	i32 663517072, ; 34: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 72
	i32 666292255, ; 35: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 21
	i32 690569205, ; 36: System.Xml.Linq.dll => 0x29293ff5 => 15
	i32 691348768, ; 37: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 94
	i32 700284507, ; 38: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 89
	i32 720511267, ; 39: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 93
	i32 775507847, ; 40: System.IO.Compression => 0x2e394f87 => 104
	i32 809851609, ; 41: System.Drawing.Common.dll => 0x30455ad9 => 103
	i32 843511501, ; 42: Xamarin.AndroidX.Print => 0x3246f6cd => 60
	i32 869734198, ; 43: XamarinVideoPlayer.Droid => 0x33d71736 => 97
	i32 928116545, ; 44: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 84
	i32 956575887, ; 45: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 93
	i32 967690846, ; 46: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 45
	i32 974778368, ; 47: FormsViewGroup.dll => 0x3a19f000 => 5
	i32 1012816738, ; 48: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 64
	i32 1035644815, ; 49: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 20
	i32 1042160112, ; 50: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 81
	i32 1052210849, ; 51: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 50
	i32 1084122840, ; 52: Xamarin.Kotlin.StdLib => 0x409e66d8 => 91
	i32 1098259244, ; 53: System => 0x41761b2c => 10
	i32 1175144683, ; 54: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 70
	i32 1178241025, ; 55: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 57
	i32 1204270330, ; 56: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 21
	i32 1264511973, ; 57: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 66
	i32 1267360935, ; 58: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 71
	i32 1275534314, ; 59: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 94
	i32 1293217323, ; 60: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 36
	i32 1365406463, ; 61: System.ServiceModel.Internals.dll => 0x516272ff => 98
	i32 1376866003, ; 62: Xamarin.AndroidX.SavedState => 0x52114ed3 => 64
	i32 1379779777, ; 63: System.Resources.ResourceManager => 0x523dc4c1 => 3
	i32 1395857551, ; 64: Xamarin.AndroidX.Media.dll => 0x5333188f => 54
	i32 1406073936, ; 65: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 30
	i32 1460219004, ; 66: Xamarin.Forms.Xaml => 0x57092c7c => 82
	i32 1462112819, ; 67: System.IO.Compression.dll => 0x57261233 => 104
	i32 1469204771, ; 68: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 19
	i32 1530663695, ; 69: Xamarin.Forms.Maps.dll => 0x5b3c130f => 79
	i32 1582372066, ; 70: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 35
	i32 1591216029, ; 71: EasyPatagonia => 0x5ed8079d => 4
	i32 1592978981, ; 72: System.Runtime.Serialization.dll => 0x5ef2ee25 => 2
	i32 1622152042, ; 73: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 52
	i32 1624863272, ; 74: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 74
	i32 1635184631, ; 75: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 39
	i32 1636350590, ; 76: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 33
	i32 1639515021, ; 77: System.Net.Http.dll => 0x61b9038d => 1
	i32 1657153582, ; 78: System.Runtime => 0x62c6282e => 13
	i32 1658241508, ; 79: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 68
	i32 1658251792, ; 80: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 83
	i32 1670060433, ; 81: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 29
	i32 1698840827, ; 82: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 90
	i32 1729485958, ; 83: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 25
	i32 1766324549, ; 84: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 67
	i32 1776026572, ; 85: System.Core.dll => 0x69dc03cc => 9
	i32 1788241197, ; 86: Xamarin.AndroidX.Fragment => 0x6a96652d => 40
	i32 1808609942, ; 87: Xamarin.AndroidX.Loader => 0x6bcd3296 => 52
	i32 1813058853, ; 88: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 91
	i32 1813201214, ; 89: Xamarin.Google.Android.Material => 0x6c13413e => 83
	i32 1818569960, ; 90: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 58
	i32 1867746548, ; 91: Xamarin.Essentials.dll => 0x6f538cf4 => 76
	i32 1878053835, ; 92: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 82
	i32 1881862856, ; 93: Xamarin.Forms.Maps.Android.dll => 0x702af2c8 => 78
	i32 1885316902, ; 94: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 22
	i32 1900610850, ; 95: System.Resources.ResourceManager.dll => 0x71490522 => 3
	i32 1908813208, ; 96: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 86
	i32 1919157823, ; 97: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 55
	i32 1983156543, ; 98: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 90
	i32 2019465201, ; 99: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 50
	i32 2055257422, ; 100: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 46
	i32 2079903147, ; 101: System.Runtime.dll => 0x7bf8cdab => 13
	i32 2090596640, ; 102: System.Numerics.Vectors => 0x7c9bf920 => 12
	i32 2097448633, ; 103: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 42
	i32 2126786730, ; 104: Xamarin.Forms.Platform.Android => 0x7ec430aa => 80
	i32 2129483829, ; 105: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 85
	i32 2193016926, ; 106: System.ObjectModel.dll => 0x82b6c85e => 109
	i32 2201107256, ; 107: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 95
	i32 2201231467, ; 108: System.Net.Http => 0x8334206b => 1
	i32 2217644978, ; 109: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 70
	i32 2244775296, ; 110: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 53
	i32 2256548716, ; 111: Xamarin.AndroidX.MultiDex => 0x8680336c => 55
	i32 2261435625, ; 112: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 44
	i32 2279755925, ; 113: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 62
	i32 2315684594, ; 114: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 17
	i32 2403452196, ; 115: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 38
	i32 2409053734, ; 116: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 59
	i32 2465532216, ; 117: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 28
	i32 2471841756, ; 118: netstandard.dll => 0x93554fdc => 99
	i32 2475788418, ; 119: Java.Interop.dll => 0x93918882 => 6
	i32 2501346920, ; 120: System.Data.DataSetExtensions => 0x95178668 => 102
	i32 2505896520, ; 121: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 49
	i32 2581819634, ; 122: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 71
	i32 2605712449, ; 123: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 95
	i32 2620871830, ; 124: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 33
	i32 2624644809, ; 125: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 37
	i32 2633051222, ; 126: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 47
	i32 2652342592, ; 127: XamarinVideoPlayer.Droid.dll => 0x9e178940 => 97
	i32 2701096212, ; 128: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 68
	i32 2715334215, ; 129: System.Threading.Tasks.dll => 0xa1d8b647 => 110
	i32 2732626843, ; 130: Xamarin.AndroidX.Activity => 0xa2e0939b => 16
	i32 2737747696, ; 131: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 19
	i32 2766581644, ; 132: Xamarin.Forms.Core => 0xa4e6af8c => 77
	i32 2770495804, ; 133: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 89
	i32 2778768386, ; 134: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 73
	i32 2779977773, ; 135: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 63
	i32 2810250172, ; 136: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 30
	i32 2819470561, ; 137: System.Xml.dll => 0xa80db4e1 => 14
	i32 2821294376, ; 138: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 63
	i32 2847418871, ; 139: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 85
	i32 2853208004, ; 140: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 73
	i32 2855708567, ; 141: Xamarin.AndroidX.Transition => 0xaa36a797 => 69
	i32 2903344695, ; 142: System.ComponentModel.Composition => 0xad0d8637 => 106
	i32 2905242038, ; 143: mscorlib.dll => 0xad2a79b6 => 8
	i32 2916838712, ; 144: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 74
	i32 2919462931, ; 145: System.Numerics.Vectors.dll => 0xae037813 => 12
	i32 2921128767, ; 146: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 18
	i32 2978675010, ; 147: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 36
	i32 2996846495, ; 148: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 48
	i32 3016983068, ; 149: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 66
	i32 3017076677, ; 150: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 87
	i32 3024354802, ; 151: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 43
	i32 3044182254, ; 152: FormsViewGroup => 0xb57288ee => 5
	i32 3057625584, ; 153: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 56
	i32 3058099980, ; 154: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 88
	i32 3075834255, ; 155: System.Threading.Tasks => 0xb755818f => 110
	i32 3111772706, ; 156: System.Runtime.Serialization => 0xb979e222 => 2
	i32 3204380047, ; 157: System.Data.dll => 0xbefef58f => 100
	i32 3211777861, ; 158: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 35
	i32 3230466174, ; 159: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 86
	i32 3244405854, ; 160: XamarinVideoPlayer.dll => 0xc161b45e => 96
	i32 3247949154, ; 161: Mono.Security => 0xc197c562 => 108
	i32 3258312781, ; 162: Xamarin.AndroidX.CardView => 0xc235e84d => 25
	i32 3260061975, ; 163: EasyPatagonia.Android.dll => 0xc2509917 => 0
	i32 3267021929, ; 164: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 23
	i32 3317135071, ; 165: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 34
	i32 3317144872, ; 166: System.Data => 0xc5b79d28 => 100
	i32 3340431453, ; 167: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 22
	i32 3345895724, ; 168: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 61
	i32 3346324047, ; 169: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 57
	i32 3353484488, ; 170: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 42
	i32 3353544232, ; 171: Xamarin.CommunityToolkit.dll => 0xc7e30628 => 75
	i32 3362522851, ; 172: Xamarin.AndroidX.Core => 0xc86c06e3 => 32
	i32 3366347497, ; 173: Java.Interop => 0xc8a662e9 => 6
	i32 3374999561, ; 174: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 62
	i32 3404865022, ; 175: System.ServiceModel.Internals => 0xcaf21dfe => 98
	i32 3407215217, ; 176: Xamarin.CommunityToolkit => 0xcb15fa71 => 75
	i32 3429136800, ; 177: System.Xml => 0xcc6479a0 => 14
	i32 3430777524, ; 178: netstandard => 0xcc7d82b4 => 99
	i32 3441283291, ; 179: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 37
	i32 3476120550, ; 180: Mono.Android => 0xcf3163e6 => 7
	i32 3486566296, ; 181: System.Transactions => 0xcfd0c798 => 101
	i32 3493954962, ; 182: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 27
	i32 3501239056, ; 183: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 23
	i32 3509114376, ; 184: System.Xml.Linq => 0xd128d608 => 15
	i32 3536029504, ; 185: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 80
	i32 3549130245, ; 186: EasyPatagonia.Android => 0xd38b6e05 => 0
	i32 3567349600, ; 187: System.ComponentModel.Composition.dll => 0xd4a16f60 => 106
	i32 3618140916, ; 188: Xamarin.AndroidX.Preference => 0xd7a872f4 => 59
	i32 3627220390, ; 189: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 60
	i32 3632359727, ; 190: Xamarin.Forms.Platform => 0xd881692f => 81
	i32 3633644679, ; 191: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 18
	i32 3641597786, ; 192: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 46
	i32 3672681054, ; 193: Mono.Android.dll => 0xdae8aa5e => 7
	i32 3676310014, ; 194: System.Web.Services.dll => 0xdb2009fe => 107
	i32 3682565725, ; 195: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 24
	i32 3684561358, ; 196: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 27
	i32 3689375977, ; 197: System.Drawing.Common => 0xdbe768e9 => 103
	i32 3706696989, ; 198: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 31
	i32 3718780102, ; 199: Xamarin.AndroidX.Annotation => 0xdda814c6 => 17
	i32 3724971120, ; 200: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 56
	i32 3758932259, ; 201: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 44
	i32 3786282454, ; 202: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 26
	i32 3822602673, ; 203: Xamarin.AndroidX.Media => 0xe3d849b1 => 54
	i32 3829621856, ; 204: System.Numerics.dll => 0xe4436460 => 11
	i32 3885922214, ; 205: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 69
	i32 3888767677, ; 206: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 61
	i32 3896760992, ; 207: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 32
	i32 3920810846, ; 208: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 105
	i32 3921031405, ; 209: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 72
	i32 3931092270, ; 210: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 58
	i32 3945713374, ; 211: System.Data.DataSetExtensions.dll => 0xeb2ecede => 102
	i32 3955647286, ; 212: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 20
	i32 3959773229, ; 213: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 48
	i32 3970018735, ; 214: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 88
	i32 4101593132, ; 215: Xamarin.AndroidX.Emoji2 => 0xf479582c => 38
	i32 4105002889, ; 216: Mono.Security.dll => 0xf4ad5f89 => 108
	i32 4151237749, ; 217: System.Core => 0xf76edc75 => 9
	i32 4182413190, ; 218: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 51
	i32 4256097574, ; 219: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 31
	i32 4278134329, ; 220: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 87
	i32 4292120959 ; 221: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 51
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [222 x i32] [
	i32 49, i32 84, i32 77, i32 65, i32 65, i32 92, i32 26, i32 67, ; 0..7
	i32 24, i32 78, i32 43, i32 107, i32 29, i32 47, i32 41, i32 16, ; 8..15
	i32 79, i32 11, i32 45, i32 28, i32 76, i32 40, i32 8, i32 10, ; 16..23
	i32 41, i32 53, i32 109, i32 101, i32 92, i32 96, i32 105, i32 4, ; 24..31
	i32 34, i32 39, i32 72, i32 21, i32 15, i32 94, i32 89, i32 93, ; 32..39
	i32 104, i32 103, i32 60, i32 97, i32 84, i32 93, i32 45, i32 5, ; 40..47
	i32 64, i32 20, i32 81, i32 50, i32 91, i32 10, i32 70, i32 57, ; 48..55
	i32 21, i32 66, i32 71, i32 94, i32 36, i32 98, i32 64, i32 3, ; 56..63
	i32 54, i32 30, i32 82, i32 104, i32 19, i32 79, i32 35, i32 4, ; 64..71
	i32 2, i32 52, i32 74, i32 39, i32 33, i32 1, i32 13, i32 68, ; 72..79
	i32 83, i32 29, i32 90, i32 25, i32 67, i32 9, i32 40, i32 52, ; 80..87
	i32 91, i32 83, i32 58, i32 76, i32 82, i32 78, i32 22, i32 3, ; 88..95
	i32 86, i32 55, i32 90, i32 50, i32 46, i32 13, i32 12, i32 42, ; 96..103
	i32 80, i32 85, i32 109, i32 95, i32 1, i32 70, i32 53, i32 55, ; 104..111
	i32 44, i32 62, i32 17, i32 38, i32 59, i32 28, i32 99, i32 6, ; 112..119
	i32 102, i32 49, i32 71, i32 95, i32 33, i32 37, i32 47, i32 97, ; 120..127
	i32 68, i32 110, i32 16, i32 19, i32 77, i32 89, i32 73, i32 63, ; 128..135
	i32 30, i32 14, i32 63, i32 85, i32 73, i32 69, i32 106, i32 8, ; 136..143
	i32 74, i32 12, i32 18, i32 36, i32 48, i32 66, i32 87, i32 43, ; 144..151
	i32 5, i32 56, i32 88, i32 110, i32 2, i32 100, i32 35, i32 86, ; 152..159
	i32 96, i32 108, i32 25, i32 0, i32 23, i32 34, i32 100, i32 22, ; 160..167
	i32 61, i32 57, i32 42, i32 75, i32 32, i32 6, i32 62, i32 98, ; 168..175
	i32 75, i32 14, i32 99, i32 37, i32 7, i32 101, i32 27, i32 23, ; 176..183
	i32 15, i32 80, i32 0, i32 106, i32 59, i32 60, i32 81, i32 18, ; 184..191
	i32 46, i32 7, i32 107, i32 24, i32 27, i32 103, i32 31, i32 17, ; 192..199
	i32 56, i32 44, i32 26, i32 54, i32 11, i32 69, i32 61, i32 32, ; 200..207
	i32 105, i32 72, i32 58, i32 102, i32 20, i32 48, i32 88, i32 38, ; 208..215
	i32 108, i32 9, i32 51, i32 31, i32 87, i32 51 ; 216..221
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a8a26c7b003e2524cc98acb2c2ffc2ddea0f6692"}
!llvm.linker.options = !{}
