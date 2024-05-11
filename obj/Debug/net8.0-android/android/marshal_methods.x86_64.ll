; ModuleID = 'marshal_methods.x86_64.ll'
source_filename = "marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [320 x ptr] zeroinitializer, align 16

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [640 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 230
	i64 98382396393917666, ; 1: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 190
	i64 120698629574877762, ; 2: Mono.Android => 0x1accec39cafe242 => 171
	i64 131669012237370309, ; 3: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 195
	i64 196720943101637631, ; 4: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 58
	i64 210515253464952879, ; 5: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 217
	i64 229794953483747371, ; 6: System.ValueTuple.dll => 0x330654aed93802b => 151
	i64 232391251801502327, ; 7: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 258
	i64 295915112840604065, ; 8: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 261
	i64 316157742385208084, ; 9: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 224
	i64 350667413455104241, ; 10: System.ServiceProcess.dll => 0x4ddd227954be8f1 => 132
	i64 422779754995088667, ; 11: System.IO.UnmanagedMemoryStream => 0x5de03f27ab57d1b => 56
	i64 435118502366263740, ; 12: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x609d9f8f8bdb9bc => 260
	i64 560278790331054453, ; 13: System.Reflection.Primitives => 0x7c6829760de3975 => 95
	i64 634308326490598313, ; 14: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 243
	i64 649145001856603771, ; 15: System.Security.SecureString => 0x90239f09b62167b => 129
	i64 750875890346172408, ; 16: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 145
	i64 798450721097591769, ; 17: Xamarin.AndroidX.Collection.Ktx.dll => 0xb14aab351ad2bd9 => 218
	i64 799765834175365804, ; 18: System.ComponentModel.dll => 0xb1956c9f18442ac => 18
	i64 805302231655005164, ; 19: hu\Microsoft.Maui.Controls.resources.dll => 0xb2d021ceea03bec => 297
	i64 872800313462103108, ; 20: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 229
	i64 895210737996778430, ; 21: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0xc6c6d6c5569cbbe => 244
	i64 940822596282819491, ; 22: System.Transactions => 0xd0e792aa81923a3 => 150
	i64 960778385402502048, ; 23: System.Runtime.Handles.dll => 0xd555ed9e1ca1ba0 => 104
	i64 985332033409892329, ; 24: System.Net.Http.Primitives => 0xdac9a438d35bfe9 => 198
	i64 1010599046655515943, ; 25: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 95
	i64 1120440138749646132, ; 26: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 273
	i64 1268860745194512059, ; 27: System.Drawing.dll => 0x119be62002c19ebb => 36
	i64 1301626418029409250, ; 28: System.Diagnostics.FileVersionInfo => 0x12104e54b4e833e2 => 28
	i64 1315114680217950157, ; 29: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 213
	i64 1369545283391376210, ; 30: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 251
	i64 1404195534211153682, ; 31: System.IO.FileSystem.Watcher.dll => 0x137cb4660bd87f12 => 50
	i64 1425944114962822056, ; 32: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 115
	i64 1476839205573959279, ; 33: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 70
	i64 1486715745332614827, ; 34: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 192
	i64 1492954217099365037, ; 35: System.Net.HttpListener => 0x14b809f350210aad => 65
	i64 1513467482682125403, ; 36: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 170
	i64 1537168428375924959, ; 37: System.Threading.Thread.dll => 0x15551e8a954ae0df => 145
	i64 1576750169145655260, ; 38: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x15e1bdecc376bfdc => 272
	i64 1624659445732251991, ; 39: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 212
	i64 1628611045998245443, ; 40: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 247
	i64 1636321030536304333, ; 41: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 237
	i64 1651782184287836205, ; 42: System.Globalization.Calendars => 0x16ec4f2524cb982d => 40
	i64 1659332977923810219, ; 43: System.Reflection.DispatchProxy => 0x1707228d493d63ab => 89
	i64 1682513316613008342, ; 44: System.Net.dll => 0x17597cf276952bd6 => 81
	i64 1696201532211667577, ; 45: Microsoft.Threading.Tasks.Extensions.dll => 0x178a1e4e82f32279 => 180
	i64 1731380447121279447, ; 46: Newtonsoft.Json => 0x18071957e9b889d7 => 199
	i64 1735388228521408345, ; 47: System.Net.Mail.dll => 0x181556663c69b759 => 66
	i64 1743969030606105336, ; 48: System.Memory.dll => 0x1833d297e88f2af8 => 62
	i64 1767386781656293639, ; 49: System.Private.Uri.dll => 0x188704e9f5582107 => 86
	i64 1795316252682057001, ; 50: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 211
	i64 1825687700144851180, ; 51: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 106
	i64 1835311033149317475, ; 52: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 291
	i64 1836611346387731153, ; 53: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 258
	i64 1854145951182283680, ; 54: System.Runtime.CompilerServices.VisualC => 0x19bb3feb3df2e3a0 => 102
	i64 1875417405349196092, ; 55: System.Drawing.Primitives => 0x1a06d2319b6c713c => 35
	i64 1875917498431009007, ; 56: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 208
	i64 1881198190668717030, ; 57: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 313
	i64 1897575647115118287, ; 58: Xamarin.AndroidX.Security.SecurityCrypto => 0x1a558aff4cba86cf => 260
	i64 1920760634179481754, ; 59: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 193
	i64 1930726298510463061, ; 60: CommunityToolkit.Mvvm.dll => 0x1acb5156cd389055 => 175
	i64 1972385128188460614, ; 61: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 119
	i64 1981742497975770890, ; 62: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 245
	i64 2040001226662520565, ; 63: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 142
	i64 2062890601515140263, ; 64: System.Threading.Tasks.Dataflow => 0x1ca0dc1289cd44a7 => 141
	i64 2064708342624596306, ; 65: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x1ca7514c5eecb152 => 281
	i64 2080945842184875448, ; 66: System.IO.MemoryMappedFiles => 0x1ce10137d8416db8 => 53
	i64 2102659300918482391, ; 67: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 35
	i64 2106033277907880740, ; 68: System.Threading.Tasks.Dataflow.dll => 0x1d3a221ba6d9cb24 => 141
	i64 2133195048986300728, ; 69: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 199
	i64 2165310824878145998, ; 70: Xamarin.Android.Glide.GifDecoder => 0x1e0cbab9112b81ce => 205
	i64 2165725771938924357, ; 71: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 215
	i64 2200176636225660136, ; 72: Microsoft.Extensions.Logging.Debug.dll => 0x1e8898fe5d5824e8 => 188
	i64 2262844636196693701, ; 73: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 229
	i64 2287834202362508563, ; 74: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 8
	i64 2287887973817120656, ; 75: System.ComponentModel.DataAnnotations.dll => 0x1fc035fd8d41f790 => 14
	i64 2304837677853103545, ; 76: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0x1ffc6da80d5ed5b9 => 257
	i64 2315304989185124968, ; 77: System.IO.FileSystem.dll => 0x20219d9ee311aa68 => 51
	i64 2329709569556905518, ; 78: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 240
	i64 2335503487726329082, ; 79: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 136
	i64 2337758774805907496, ; 80: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 101
	i64 2470498323731680442, ; 81: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 222
	i64 2479423007379663237, ; 82: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 267
	i64 2497223385847772520, ; 83: System.Runtime => 0x22a7eb7046413568 => 116
	i64 2547086958574651984, ; 84: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 206
	i64 2592350477072141967, ; 85: System.Xml.dll => 0x23f9e10627330e8f => 163
	i64 2602673633151553063, ; 86: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 312
	i64 2624866290265602282, ; 87: mscorlib.dll => 0x246d65fbde2db8ea => 166
	i64 2632269733008246987, ; 88: System.Net.NameResolution => 0x2487b36034f808cb => 67
	i64 2656907746661064104, ; 89: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 184
	i64 2662981627730767622, ; 90: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 287
	i64 2706075432581334785, ; 91: System.Net.WebSockets => 0x258de944be6c0701 => 80
	i64 2783046991838674048, ; 92: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 101
	i64 2787234703088983483, ; 93: Xamarin.AndroidX.Startup.StartupRuntime => 0x26ae3f31ef429dbb => 262
	i64 2815524396660695947, ; 94: System.Security.AccessControl => 0x2712c0857f68238b => 117
	i64 2895129759130297543, ; 95: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 292
	i64 2923871038697555247, ; 96: Jsr305Binding => 0x2893ad37e69ec52f => 274
	i64 3017136373564924869, ; 97: System.Net.WebProxy => 0x29df058bd93f63c5 => 78
	i64 3017704767998173186, ; 98: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 273
	i64 3106852385031680087, ; 99: System.Runtime.Serialization.Xml => 0x2b1dc1c88b637057 => 114
	i64 3110390492489056344, ; 100: System.Security.Cryptography.Csp.dll => 0x2b2a53ac61900058 => 121
	i64 3135773902340015556, ; 101: System.IO.FileSystem.DriveInfo.dll => 0x2b8481c008eac5c4 => 48
	i64 3281594302220646930, ; 102: System.Security.Principal => 0x2d8a90a198ceba12 => 128
	i64 3289520064315143713, ; 103: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 238
	i64 3303437397778967116, ; 104: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 209
	i64 3311221304742556517, ; 105: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 82
	i64 3325875462027654285, ; 106: System.Runtime.Numerics => 0x2e27e21c8958b48d => 110
	i64 3328853167529574890, ; 107: System.Net.Sockets.dll => 0x2e327651a008c1ea => 75
	i64 3344514922410554693, ; 108: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 284
	i64 3429672777697402584, ; 109: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 195
	i64 3437845325506641314, ; 110: System.IO.MemoryMappedFiles.dll => 0x2fb5ae1beb8f7da2 => 53
	i64 3493805808809882663, ; 111: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 264
	i64 3494946837667399002, ; 112: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 182
	i64 3508450208084372758, ; 113: System.Net.Ping => 0x30b084e02d03ad16 => 69
	i64 3522470458906976663, ; 114: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 263
	i64 3531994851595924923, ; 115: System.Numerics => 0x31042a9aade235bb => 83
	i64 3551103847008531295, ; 116: System.Private.CoreLib.dll => 0x31480e226177735f => 172
	i64 3567343442040498961, ; 117: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 307
	i64 3571415421602489686, ; 118: System.Runtime.dll => 0x319037675df7e556 => 116
	i64 3638003163729360188, ; 119: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 183
	i64 3647754201059316852, ; 120: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 156
	i64 3655542548057982301, ; 121: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 182
	i64 3659371656528649588, ; 122: Xamarin.Android.Glide.Annotations => 0x32c8b3222885dd74 => 203
	i64 3716579019761409177, ; 123: netstandard.dll => 0x3393f0ed5c8c5c99 => 167
	i64 3727469159507183293, ; 124: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 256
	i64 3772598417116884899, ; 125: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 230
	i64 3869221888984012293, ; 126: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 186
	i64 3869649043256705283, ; 127: System.Diagnostics.Tools => 0x35b3c14d74bf0103 => 32
	i64 3890352374528606784, ; 128: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 193
	i64 3919223565570527920, ; 129: System.Security.Cryptography.Encoding => 0x3663e111652bd2b0 => 122
	i64 3933965368022646939, ; 130: System.Net.Requests => 0x369840a8bfadc09b => 72
	i64 3966267475168208030, ; 131: System.Memory => 0x370b03412596249e => 62
	i64 4006972109285359177, ; 132: System.Xml.XmlDocument => 0x379b9fe74ed9fe49 => 161
	i64 4009997192427317104, ; 133: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 113
	i64 4070326265757318011, ; 134: da\Microsoft.Maui.Controls.resources.dll => 0x387cb42c56683b7b => 288
	i64 4073500526318903918, ; 135: System.Private.Xml.dll => 0x3887fb25779ae26e => 88
	i64 4073631083018132676, ; 136: Microsoft.Maui.Controls.Compatibility.dll => 0x388871e311491cc4 => 191
	i64 4120493066591692148, ; 137: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 318
	i64 4148881117810174540, ; 138: System.Runtime.InteropServices.JavaScript.dll => 0x3993c9651a66aa4c => 105
	i64 4154383907710350974, ; 139: System.ComponentModel => 0x39a7562737acb67e => 18
	i64 4167269041631776580, ; 140: System.Threading.ThreadPool => 0x39d51d1d3df1cf44 => 146
	i64 4168469861834746866, ; 141: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 118
	i64 4187479170553454871, ; 142: System.Linq.Expressions => 0x3a1cea1e912fa117 => 58
	i64 4201423742386704971, ; 143: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 224
	i64 4205801962323029395, ; 144: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 17
	i64 4235503420553921860, ; 145: System.IO.IsolatedStorage.dll => 0x3ac787eb9b118544 => 52
	i64 4282138915307457788, ; 146: System.Reflection.Emit => 0x3b6d36a7ddc70cfc => 92
	i64 4360412976914417659, ; 147: tr\Microsoft.Maui.Controls.resources.dll => 0x3c834c8002fcc7fb => 313
	i64 4373617458794931033, ; 148: System.IO.Pipes.dll => 0x3cb235e806eb2359 => 55
	i64 4389024575735330464, ; 149: FireSharp.dll => 0x3ce8f298fb29f6a0 => 178
	i64 4397634830160618470, ; 150: System.Security.SecureString.dll => 0x3d0789940f9be3e6 => 129
	i64 4477672992252076438, ; 151: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 152
	i64 4484706122338676047, ; 152: System.Globalization.Extensions.dll => 0x3e3ce07510042d4f => 41
	i64 4533124835995628778, ; 153: System.Reflection.Emit.dll => 0x3ee8e505540534ea => 92
	i64 4636684751163556186, ; 154: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 268
	i64 4672453897036726049, ; 155: System.IO.FileSystem.Watcher => 0x40d7e4104a437f21 => 50
	i64 4716677666592453464, ; 156: System.Xml.XmlSerializer => 0x417501590542f358 => 162
	i64 4743821336939966868, ; 157: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 13
	i64 4759461199762736555, ; 158: Xamarin.AndroidX.Lifecycle.Process.dll => 0x420d00be961cc5ab => 242
	i64 4794310189461587505, ; 159: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 206
	i64 4795410492532947900, ; 160: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 263
	i64 4809057822547766521, ; 161: System.Drawing => 0x42bd349c3145ecf9 => 36
	i64 4814660307502931973, ; 162: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 67
	i64 4853321196694829351, ; 163: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 109
	i64 4871824391508510238, ; 164: nb\Microsoft.Maui.Controls.resources.dll => 0x439c3278d7f2c61e => 303
	i64 4953714692329509532, ; 165: sv\Microsoft.Maui.Controls.resources.dll => 0x44bf21444aef129c => 311
	i64 5055365687667823624, ; 166: Xamarin.AndroidX.Activity.Ktx.dll => 0x4628444ef7239408 => 207
	i64 5081566143765835342, ; 167: System.Resources.ResourceManager.dll => 0x4685597c05d06e4e => 99
	i64 5099468265966638712, ; 168: System.Resources.ResourceManager => 0x46c4f35ea8519678 => 99
	i64 5103417709280584325, ; 169: System.Collections.Specialized => 0x46d2fb5e161b6285 => 11
	i64 5182934613077526976, ; 170: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 11
	i64 5202753749449073649, ; 171: Plugin.Media => 0x4833e4f841be63f1 => 201
	i64 5205316157927637098, ; 172: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 249
	i64 5244375036463807528, ; 173: System.Diagnostics.Contracts.dll => 0x48c7c34f4d59fc28 => 25
	i64 5262971552273843408, ; 174: System.Security.Principal.dll => 0x4909d4be0c44c4d0 => 128
	i64 5278787618751394462, ; 175: System.Net.WebClient.dll => 0x4942055efc68329e => 76
	i64 5280980186044710147, ; 176: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x4949cf7fd7123d03 => 241
	i64 5290786973231294105, ; 177: System.Runtime.Loader => 0x496ca6b869b72699 => 109
	i64 5376510917114486089, ; 178: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 267
	i64 5408338804355907810, ; 179: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 265
	i64 5423376490970181369, ; 180: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 106
	i64 5440320908473006344, ; 181: Microsoft.VisualBasic.Core => 0x4b7fe70acda9f908 => 2
	i64 5446034149219586269, ; 182: System.Diagnostics.Debug => 0x4b94333452e150dd => 26
	i64 5451019430259338467, ; 183: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 220
	i64 5457765010617926378, ; 184: System.Xml.Serialization => 0x4bbde05c557002ea => 157
	i64 5471532531798518949, ; 185: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 311
	i64 5507995362134886206, ; 186: System.Core.dll => 0x4c705499688c873e => 21
	i64 5522859530602327440, ; 187: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 314
	i64 5527431512186326818, ; 188: System.IO.FileSystem.Primitives.dll => 0x4cb561acbc2a8f22 => 49
	i64 5570799893513421663, ; 189: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 43
	i64 5573260873512690141, ; 190: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 126
	i64 5574231584441077149, ; 191: Xamarin.AndroidX.Annotation.Jvm => 0x4d5ba617ae5f8d9d => 210
	i64 5591791169662171124, ; 192: System.Linq.Parallel => 0x4d9a087135e137f4 => 59
	i64 5650097808083101034, ; 193: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 119
	i64 5692067934154308417, ; 194: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 270
	i64 5724799082821825042, ; 195: Xamarin.AndroidX.ExifInterface => 0x4f72926f3e13b212 => 233
	i64 5757522595884336624, ; 196: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 219
	i64 5783556987928984683, ; 197: Microsoft.VisualBasic => 0x504352701bbc3c6b => 3
	i64 5896680224035167651, ; 198: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 239
	i64 5959344983920014087, ; 199: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x52b3d8b05c8ef307 => 259
	i64 5979151488806146654, ; 200: System.Formats.Asn1 => 0x52fa3699a489d25e => 38
	i64 5984759512290286505, ; 201: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 124
	i64 6102788177522843259, ; 202: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0x54b1758374b3de7b => 259
	i64 6200764641006662125, ; 203: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 308
	i64 6218967553231149354, ; 204: Firebase.Auth.dll => 0x564e360a4805d92a => 176
	i64 6222399776351216807, ; 205: System.Text.Json.dll => 0x565a67a0ffe264a7 => 137
	i64 6251069312384999852, ; 206: System.Transactions.Local => 0x56c0426b870da1ac => 149
	i64 6278736998281604212, ; 207: System.Private.DataContractSerialization => 0x57228e08a4ad6c74 => 85
	i64 6284145129771520194, ; 208: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 90
	i64 6300676701234028427, ; 209: es\Microsoft.Maui.Controls.resources.dll => 0x57708013cda25f8b => 291
	i64 6319713645133255417, ; 210: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 243
	i64 6357457916754632952, ; 211: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 319
	i64 6401687960814735282, ; 212: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 240
	i64 6471714727257221498, ; 213: fi\Microsoft.Maui.Controls.resources.dll => 0x59d026417dd4a97a => 292
	i64 6478287442656530074, ; 214: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 296
	i64 6504860066809920875, ; 215: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 215
	i64 6548213210057960872, ; 216: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 226
	i64 6557084851308642443, ; 217: Xamarin.AndroidX.Window.dll => 0x5aff71ee6c58c08b => 271
	i64 6560151584539558821, ; 218: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 189
	i64 6589202984700901502, ; 219: Xamarin.Google.ErrorProne.Annotations.dll => 0x5b718d34180a787e => 276
	i64 6591971792923354531, ; 220: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x5b7b636b7e9765a3 => 241
	i64 6617685658146568858, ; 221: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 133
	i64 6713440830605852118, ; 222: System.Reflection.TypeExtensions.dll => 0x5d2aeeddb8dd7dd6 => 96
	i64 6739853162153639747, ; 223: Microsoft.VisualBasic.dll => 0x5d88c4bde075ff43 => 3
	i64 6743165466166707109, ; 224: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 304
	i64 6772837112740759457, ; 225: System.Runtime.InteropServices.JavaScript => 0x5dfdf378527ec7a1 => 105
	i64 6786606130239981554, ; 226: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 33
	i64 6798329586179154312, ; 227: System.Windows => 0x5e5884bd523ca188 => 154
	i64 6814185388980153342, ; 228: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 158
	i64 6876862101832370452, ; 229: System.Xml.Linq => 0x5f6f85a57d108914 => 155
	i64 6893283808111824265, ; 230: Plugin.Maui.Calendar.dll => 0x5fa9dd19ee750d89 => 200
	i64 6894844156784520562, ; 231: System.Numerics.Vectors => 0x5faf683aead1ad72 => 82
	i64 7011053663211085209, ; 232: Xamarin.AndroidX.Fragment.Ktx => 0x614c442918e5dd99 => 235
	i64 7060896174307865760, ; 233: System.Threading.Tasks.Parallel.dll => 0x61fd57a90988f4a0 => 143
	i64 7083547580668757502, ; 234: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 87
	i64 7101497697220435230, ; 235: System.Configuration => 0x628d9687c0141d1e => 19
	i64 7103753931438454322, ; 236: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 236
	i64 7112547816752919026, ; 237: System.IO.FileSystem => 0x62b4d88e3189b1f2 => 51
	i64 7192745174564810625, ; 238: Xamarin.Android.Glide.GifDecoder.dll => 0x63d1c3a0a1d72f81 => 205
	i64 7270811800166795866, ; 239: System.Linq => 0x64e71ccf51a90a5a => 61
	i64 7299370801165188114, ; 240: System.IO.Pipes.AccessControl.dll => 0x654c9311e74f3c12 => 54
	i64 7316205155833392065, ; 241: Microsoft.Win32.Primitives => 0x658861d38954abc1 => 4
	i64 7338192458477945005, ; 242: System.Reflection => 0x65d67f295d0740ad => 97
	i64 7349431895026339542, ; 243: Xamarin.Android.Glide.DiskLruCache => 0x65fe6d5e9bf88ed6 => 204
	i64 7377312882064240630, ; 244: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 17
	i64 7488575175965059935, ; 245: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 155
	i64 7489048572193775167, ; 246: System.ObjectModel => 0x67ee71ff6b419e3f => 84
	i64 7592577537120840276, ; 247: System.Diagnostics.Process => 0x695e410af5b2aa54 => 29
	i64 7637303409920963731, ; 248: System.IO.Compression.ZipFile.dll => 0x69fd26fcb637f493 => 45
	i64 7654504624184590948, ; 249: System.Net.Http => 0x6a3a4366801b8264 => 64
	i64 7694700312542370399, ; 250: System.Net.Mail => 0x6ac9112a7e2cda5f => 66
	i64 7714652370974252055, ; 251: System.Private.CoreLib => 0x6b0ff375198b9c17 => 172
	i64 7725404731275645577, ; 252: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x6b3626ac11ce9289 => 244
	i64 7735176074855944702, ; 253: Microsoft.CSharp => 0x6b58dda848e391fe => 1
	i64 7735352534559001595, ; 254: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 279
	i64 7742555799473854801, ; 255: it\Microsoft.Maui.Controls.resources.dll => 0x6b73157a51479951 => 299
	i64 7791074099216502080, ; 256: System.IO.FileSystem.AccessControl.dll => 0x6c1f749d468bcd40 => 47
	i64 7820441508502274321, ; 257: System.Data => 0x6c87ca1e14ff8111 => 24
	i64 7836164640616011524, ; 258: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 212
	i64 7975724199463739455, ; 259: sk\Microsoft.Maui.Controls.resources.dll => 0x6eaf76e6f785e03f => 310
	i64 8025517457475554965, ; 260: WindowsBase => 0x6f605d9b4786ce95 => 165
	i64 8031450141206250471, ; 261: System.Runtime.Intrinsics.dll => 0x6f757159d9dc03e7 => 108
	i64 8064050204834738623, ; 262: System.Collections.dll => 0x6fe942efa61731bf => 12
	i64 8083354569033831015, ; 263: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 238
	i64 8085230611270010360, ; 264: System.Net.Http.Json.dll => 0x703482674fdd05f8 => 63
	i64 8087206902342787202, ; 265: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 27
	i64 8103644804370223335, ; 266: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 23
	i64 8108129031893776750, ; 267: ko\Microsoft.Maui.Controls.resources.dll => 0x7085dc65530f796e => 301
	i64 8113615946733131500, ; 268: System.Reflection.Extensions => 0x70995ab73cf916ec => 93
	i64 8167236081217502503, ; 269: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 168
	i64 8185542183669246576, ; 270: System.Collections => 0x7198e33f4794aa70 => 12
	i64 8187640529827139739, ; 271: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 283
	i64 8195406069771384777, ; 272: Firebase.Storage.dll => 0x71bbee663acdb7c9 => 177
	i64 8246048515196606205, ; 273: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 196
	i64 8264926008854159966, ; 274: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 29
	i64 8290740647658429042, ; 275: System.Runtime.Extensions => 0x730ea0b15c929a72 => 103
	i64 8318905602908530212, ; 276: System.ComponentModel.DataAnnotations => 0x7372b092055ea624 => 14
	i64 8368701292315763008, ; 277: System.Security.Cryptography => 0x7423997c6fd56140 => 126
	i64 8386351099740279196, ; 278: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x74624de475b9d19c => 316
	i64 8398329775253868912, ; 279: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 221
	i64 8400357532724379117, ; 280: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 253
	i64 8410671156615598628, ; 281: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 91
	i64 8426919725312979251, ; 282: Xamarin.AndroidX.Lifecycle.Process => 0x74f26ed7aa033133 => 242
	i64 8518412311883997971, ; 283: System.Collections.Immutable => 0x76377add7c28e313 => 9
	i64 8563666267364444763, ; 284: System.Private.Uri => 0x76d841191140ca5b => 86
	i64 8598790081731763592, ; 285: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x77550a055fc61d88 => 232
	i64 8599632406834268464, ; 286: CommunityToolkit.Maui => 0x7758081c784b4930 => 173
	i64 8601935802264776013, ; 287: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 265
	i64 8623059219396073920, ; 288: System.Net.Quic.dll => 0x77ab42ac514299c0 => 71
	i64 8626175481042262068, ; 289: Java.Interop => 0x77b654e585b55834 => 168
	i64 8638972117149407195, ; 290: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 1
	i64 8639588376636138208, ; 291: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 252
	i64 8648495978913578441, ; 292: Microsoft.Win32.Registry.dll => 0x7805a1456889bdc9 => 5
	i64 8677882282824630478, ; 293: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 306
	i64 8684531736582871431, ; 294: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 44
	i64 8725526185868997716, ; 295: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 27
	i64 8824813069581120075, ; 296: Microsoft.Threading.Tasks => 0x7a7808bb1d9b724b => 181
	i64 8853378295825400934, ; 297: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 280
	i64 8941376889969657626, ; 298: System.Xml.XDocument => 0x7c1626e87187471a => 158
	i64 8951477988056063522, ; 299: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0x7c3a09cd9ccf5e22 => 255
	i64 8954753533646919997, ; 300: System.Runtime.Serialization.Json => 0x7c45ace50032d93d => 112
	i64 9045785047181495996, ; 301: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 316
	i64 9094004549068921173, ; 302: System.Net.Http.Extensions => 0x7e3464f48d0a1955 => 197
	i64 9138683372487561558, ; 303: System.Security.Cryptography.Csp => 0x7ed3201bc3e3d156 => 121
	i64 9206864077566324818, ; 304: Microsoft.Threading.Tasks.dll => 0x7fc55a1936a53052 => 181
	i64 9312692141327339315, ; 305: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 270
	i64 9324707631942237306, ; 306: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 211
	i64 9363564275759486853, ; 307: el\Microsoft.Maui.Controls.resources.dll => 0x81f21019382e9785 => 290
	i64 9468215723722196442, ; 308: System.Xml.XPath.XDocument.dll => 0x8365dc09353ac5da => 159
	i64 9551379474083066910, ; 309: uk\Microsoft.Maui.Controls.resources.dll => 0x848d5106bbadb41e => 314
	i64 9554839972845591462, ; 310: System.ServiceModel.Web => 0x84999c54e32a1ba6 => 131
	i64 9575902398040817096, ; 311: Xamarin.Google.Crypto.Tink.Android.dll => 0x84e4707ee708bdc8 => 275
	i64 9584643793929893533, ; 312: System.IO.dll => 0x85037ebfbbd7f69d => 57
	i64 9659729154652888475, ; 313: System.Text.RegularExpressions => 0x860e407c9991dd9b => 138
	i64 9662334977499516867, ; 314: System.Numerics.dll => 0x8617827802b0cfc3 => 83
	i64 9667360217193089419, ; 315: System.Diagnostics.StackTrace => 0x86295ce5cd89898b => 30
	i64 9678050649315576968, ; 316: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 222
	i64 9702891218465930390, ; 317: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 10
	i64 9773637193738963987, ; 318: ca\Microsoft.Maui.Controls.resources.dll => 0x87a2ef3ea85b4c13 => 286
	i64 9780093022148426479, ; 319: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x87b9dec9576efaef => 272
	i64 9808709177481450983, ; 320: Mono.Android.dll => 0x881f890734e555e7 => 171
	i64 9825649861376906464, ; 321: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 219
	i64 9834056768316610435, ; 322: System.Transactions.dll => 0x8879968718899783 => 150
	i64 9836529246295212050, ; 323: System.Reflection.Metadata => 0x88825f3bbc2ac012 => 94
	i64 9907349773706910547, ; 324: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x897dfa20b758db53 => 232
	i64 9933555792566666578, ; 325: System.Linq.Queryable.dll => 0x89db145cf475c552 => 60
	i64 9956195530459977388, ; 326: Microsoft.Maui => 0x8a2b8315b36616ac => 194
	i64 9974604633896246661, ; 327: System.Xml.Serialization.dll => 0x8a6cea111a59dd85 => 157
	i64 10017511394021241210, ; 328: Microsoft.Extensions.Logging.Debug => 0x8b055989ae10717a => 188
	i64 10038780035334861115, ; 329: System.Net.Http.dll => 0x8b50e941206af13b => 64
	i64 10051358222726253779, ; 330: System.Private.Xml => 0x8b7d990c97ccccd3 => 88
	i64 10078727084704864206, ; 331: System.Net.WebSockets.Client => 0x8bded4e257f117ce => 79
	i64 10089571585547156312, ; 332: System.IO.FileSystem.AccessControl => 0x8c055be67469bb58 => 47
	i64 10092835686693276772, ; 333: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 192
	i64 10105485790837105934, ; 334: System.Threading.Tasks.Parallel => 0x8c3de5c91d9a650e => 143
	i64 10143853363526200146, ; 335: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 288
	i64 10209869394718195525, ; 336: nl\Microsoft.Maui.Controls.resources.dll => 0x8db0be1ecb4f7f45 => 304
	i64 10226222362177979215, ; 337: Xamarin.Kotlin.StdLib.Jdk7 => 0x8dead70ebbc6434f => 281
	i64 10229024438826829339, ; 338: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 226
	i64 10236703004850800690, ; 339: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 74
	i64 10245369515835430794, ; 340: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 91
	i64 10321854143672141184, ; 341: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 278
	i64 10360651442923773544, ; 342: System.Text.Encoding => 0x8fc86d98211c1e68 => 135
	i64 10364469296367737616, ; 343: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 90
	i64 10376576884623852283, ; 344: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 264
	i64 10406448008575299332, ; 345: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 284
	i64 10430153318873392755, ; 346: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 223
	i64 10506226065143327199, ; 347: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 286
	i64 10546663366131771576, ; 348: System.Runtime.Serialization.Json.dll => 0x925d4673efe8e8b8 => 112
	i64 10566960649245365243, ; 349: System.Globalization.dll => 0x92a562b96dcd13fb => 42
	i64 10595762989148858956, ; 350: System.Xml.XPath.XDocument => 0x930bb64cc472ea4c => 159
	i64 10670374202010151210, ; 351: Microsoft.Win32.Primitives.dll => 0x9414c8cd7b4ea92a => 4
	i64 10714184849103829812, ; 352: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 103
	i64 10761706286639228993, ; 353: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0x955942d988382841 => 318
	i64 10785150219063592792, ; 354: System.Net.Primitives => 0x95ac8cfb68830758 => 70
	i64 10822644899632537592, ; 355: System.Linq.Queryable => 0x9631c23204ca5ff8 => 60
	i64 10830817578243619689, ; 356: System.Formats.Tar => 0x964ecb340a447b69 => 39
	i64 10847732767863316357, ; 357: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 213
	i64 10880838204485145808, ; 358: CommunityToolkit.Maui.dll => 0x970080b2a4d614d0 => 173
	i64 10899834349646441345, ; 359: System.Web => 0x9743fd975946eb81 => 153
	i64 10943875058216066601, ; 360: System.IO.UnmanagedMemoryStream.dll => 0x97e07461df39de29 => 56
	i64 10964653383833615866, ; 361: System.Diagnostics.Tracing => 0x982a4628ccaffdfa => 34
	i64 11002576679268595294, ; 362: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 187
	i64 11009005086950030778, ; 363: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 194
	i64 11019817191295005410, ; 364: Xamarin.AndroidX.Annotation.Jvm.dll => 0x98ee415998e1b2e2 => 210
	i64 11023048688141570732, ; 365: System.Core => 0x98f9bc61168392ac => 21
	i64 11037814507248023548, ; 366: System.Xml => 0x992e31d0412bf7fc => 163
	i64 11071824625609515081, ; 367: Xamarin.Google.ErrorProne.Annotations => 0x99a705d600e0a049 => 276
	i64 11103970607964515343, ; 368: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 297
	i64 11136029745144976707, ; 369: Jsr305Binding.dll => 0x9a8b200d4f8cd543 => 274
	i64 11156122287428000958, ; 370: th\Microsoft.Maui.Controls.resources.dll => 0x9ad2821cdcf6dcbe => 312
	i64 11157797727133427779, ; 371: fr\Microsoft.Maui.Controls.resources.dll => 0x9ad875ea9172e843 => 293
	i64 11162124722117608902, ; 372: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 269
	i64 11188319605227840848, ; 373: System.Threading.Overlapped => 0x9b44e5671724e550 => 140
	i64 11220793807500858938, ; 374: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 300
	i64 11226290749488709958, ; 375: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 189
	i64 11235648312900863002, ; 376: System.Reflection.DispatchProxy.dll => 0x9bed0a9c8fac441a => 89
	i64 11329751333533450475, ; 377: System.Threading.Timer.dll => 0x9d3b5ccf6cc500eb => 147
	i64 11340910727871153756, ; 378: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 225
	i64 11347436699239206956, ; 379: System.Xml.XmlSerializer.dll => 0x9d7a318e8162502c => 162
	i64 11392833485892708388, ; 380: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 254
	i64 11432101114902388181, ; 381: System.AppContext => 0x9ea6fb64e61a9dd5 => 6
	i64 11446671985764974897, ; 382: Mono.Android.Export => 0x9edabf8623efc131 => 169
	i64 11448276831755070604, ; 383: System.Diagnostics.TextWriterTraceListener => 0x9ee0731f77186c8c => 31
	i64 11485890710487134646, ; 384: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 107
	i64 11508496261504176197, ; 385: Xamarin.AndroidX.Fragment.Ktx.dll => 0x9fb664600dde1045 => 235
	i64 11518296021396496455, ; 386: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 298
	i64 11529969570048099689, ; 387: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 269
	i64 11530571088791430846, ; 388: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 186
	i64 11580057168383206117, ; 389: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 208
	i64 11591352189662810718, ; 390: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0xa0dcc167234c525e => 262
	i64 11597940890313164233, ; 391: netstandard => 0xa0f429ca8d1805c9 => 167
	i64 11672361001936329215, ; 392: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 236
	i64 11692977985522001935, ; 393: System.Threading.Overlapped.dll => 0xa245cd869980680f => 140
	i64 11707554492040141440, ; 394: System.Linq.Parallel.dll => 0xa27996c7fe94da80 => 59
	i64 11743665907891708234, ; 395: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 144
	i64 11855031688536399763, ; 396: vi\Microsoft.Maui.Controls.resources.dll => 0xa485888294361f93 => 315
	i64 11991047634523762324, ; 397: System.Net => 0xa668c24ad493ae94 => 81
	i64 12040886584167504988, ; 398: System.Net.ServicePoint => 0xa719d28d8e121c5c => 74
	i64 12063623837170009990, ; 399: System.Security => 0xa76a99f6ce740786 => 130
	i64 12096697103934194533, ; 400: System.Diagnostics.Contracts => 0xa7e019eccb7e8365 => 25
	i64 12102847907131387746, ; 401: System.Buffers => 0xa7f5f40c43256f62 => 7
	i64 12123043025855404482, ; 402: System.Reflection.Extensions.dll => 0xa83db366c0e359c2 => 93
	i64 12137774235383566651, ; 403: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 266
	i64 12145679461940342714, ; 404: System.Text.Json => 0xa88e1f1ebcb62fba => 137
	i64 12191646537372739477, ; 405: Xamarin.Android.Glide.dll => 0xa9316dee7f392795 => 202
	i64 12201331334810686224, ; 406: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 113
	i64 12269460666702402136, ; 407: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 9
	i64 12332222936682028543, ; 408: System.Runtime.Handles => 0xab24db6c07db5dff => 104
	i64 12341818387765915815, ; 409: CommunityToolkit.Maui.Core.dll => 0xab46f26f152bf0a7 => 174
	i64 12375446203996702057, ; 410: System.Configuration.dll => 0xabbe6ac12e2e0569 => 19
	i64 12451044538927396471, ; 411: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 234
	i64 12466513435562512481, ; 412: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 248
	i64 12475113361194491050, ; 413: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 319
	i64 12487638416075308985, ; 414: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 228
	i64 12517810545449516888, ; 415: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 33
	i64 12528155905152483962, ; 416: Firebase.Auth => 0xaddcf36b3153827a => 176
	i64 12538491095302438457, ; 417: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 216
	i64 12550732019250633519, ; 418: System.IO.Compression => 0xae2d28465e8e1b2f => 46
	i64 12699999919562409296, ; 419: System.Diagnostics.StackTrace.dll => 0xb03f76a3ad01c550 => 30
	i64 12700543734426720211, ; 420: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 217
	i64 12708238894395270091, ; 421: System.IO => 0xb05cbbf17d3ba3cb => 57
	i64 12708922737231849740, ; 422: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 134
	i64 12717050818822477433, ; 423: System.Runtime.Serialization.Xml.dll => 0xb07c0a5786811679 => 114
	i64 12753841065332862057, ; 424: Xamarin.AndroidX.Window => 0xb0febee04cf46c69 => 271
	i64 12828192437253469131, ; 425: Xamarin.Kotlin.StdLib.Jdk8.dll => 0xb206e50e14d873cb => 282
	i64 12835242264250840079, ; 426: System.IO.Pipes => 0xb21ff0d5d6c0740f => 55
	i64 12843321153144804894, ; 427: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 190
	i64 12843770487262409629, ; 428: System.AppContext.dll => 0xb23e3d357debf39d => 6
	i64 12859557719246324186, ; 429: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 77
	i64 12982280885948128408, ; 430: Xamarin.AndroidX.CustomView.PoolingContainer => 0xb42a53aec5481c98 => 227
	i64 12989346753972519995, ; 431: ar\Microsoft.Maui.Controls.resources.dll => 0xb4436e0d5ee7c43b => 285
	i64 13005833372463390146, ; 432: pt-BR\Microsoft.Maui.Controls.resources.dll => 0xb47e008b5d99ddc2 => 306
	i64 13068258254871114833, ; 433: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 111
	i64 13129914918964716986, ; 434: Xamarin.AndroidX.Emoji2.dll => 0xb636d40db3fe65ba => 231
	i64 13173818576982874404, ; 435: System.Runtime.CompilerServices.VisualC.dll => 0xb6d2ce32a8819924 => 102
	i64 13343850469010654401, ; 436: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 170
	i64 13370592475155966277, ; 437: System.Runtime.Serialization => 0xb98de304062ea945 => 115
	i64 13381594904270902445, ; 438: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 294
	i64 13401370062847626945, ; 439: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 266
	i64 13404347523447273790, ; 440: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 221
	i64 13431476299110033919, ; 441: System.Net.WebClient => 0xba663087f18829ff => 76
	i64 13454009404024712428, ; 442: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 277
	i64 13463706743370286408, ; 443: System.Private.DataContractSerialization.dll => 0xbad8b1f3069e0548 => 85
	i64 13465488254036897740, ; 444: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 279
	i64 13491513212026656886, ; 445: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 214
	i64 13540124433173649601, ; 446: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 315
	i64 13572454107664307259, ; 447: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 256
	i64 13578472628727169633, ; 448: System.Xml.XPath => 0xbc706ce9fba5c261 => 160
	i64 13580399111273692417, ; 449: Microsoft.VisualBasic.Core.dll => 0xbc77450a277fbd01 => 2
	i64 13621154251410165619, ; 450: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0xbd080f9faa1acf73 => 227
	i64 13643785327914841093, ; 451: Plugin.Media.dll => 0xbd587677c60cf405 => 201
	i64 13647894001087880694, ; 452: System.Data.dll => 0xbd670f48cb071df6 => 24
	i64 13675589307506966157, ; 453: Xamarin.AndroidX.Activity.Ktx => 0xbdc97404d0153e8d => 207
	i64 13702626353344114072, ; 454: System.Diagnostics.Tools.dll => 0xbe29821198fb6d98 => 32
	i64 13710614125866346983, ; 455: System.Security.AccessControl.dll => 0xbe45e2e7d0b769e7 => 117
	i64 13713329104121190199, ; 456: System.Dynamic.Runtime => 0xbe4f8829f32b5737 => 37
	i64 13717397318615465333, ; 457: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 16
	i64 13768883594457632599, ; 458: System.IO.IsolatedStorage => 0xbf14e6adb159cf57 => 52
	i64 13828521679616088467, ; 459: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 280
	i64 13881769479078963060, ; 460: System.Console.dll => 0xc0a5f3cade5c6774 => 20
	i64 13911222732217019342, ; 461: System.Security.Cryptography.OpenSsl.dll => 0xc10e975ec1226bce => 123
	i64 13928444506500929300, ; 462: System.Windows.dll => 0xc14bc67b8bba9714 => 154
	i64 13959074834287824816, ; 463: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 234
	i64 14075334701871371868, ; 464: System.ServiceModel.Web.dll => 0xc355a25647c5965c => 131
	i64 14124974489674258913, ; 465: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 216
	i64 14125464355221830302, ; 466: System.Threading.dll => 0xc407bafdbc707a9e => 148
	i64 14178052285788134900, ; 467: Xamarin.Android.Glide.Annotations.dll => 0xc4c28f6f75511df4 => 203
	i64 14212104595480609394, ; 468: System.Security.Cryptography.Cng.dll => 0xc53b89d4a4518272 => 120
	i64 14220608275227875801, ; 469: System.Diagnostics.FileVersionInfo.dll => 0xc559bfe1def019d9 => 28
	i64 14226382999226559092, ; 470: System.ServiceProcess => 0xc56e43f6938e2a74 => 132
	i64 14232023429000439693, ; 471: System.Resources.Writer.dll => 0xc5824de7789ba78d => 100
	i64 14254574811015963973, ; 472: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 134
	i64 14261073672896646636, ; 473: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 254
	i64 14298246716367104064, ; 474: System.Web.dll => 0xc66d93a217f4e840 => 153
	i64 14327695147300244862, ; 475: System.Reflection.dll => 0xc6d632d338eb4d7e => 97
	i64 14327709162229390963, ; 476: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 125
	i64 14331727281556788554, ; 477: Xamarin.Android.Glide.DiskLruCache.dll => 0xc6e48607a2f7954a => 204
	i64 14346402571976470310, ; 478: System.Net.Ping.dll => 0xc718a920f3686f26 => 69
	i64 14349907877893689639, ; 479: ro\Microsoft.Maui.Controls.resources.dll => 0xc7251d2f956ed127 => 308
	i64 14461014870687870182, ; 480: System.Net.Requests.dll => 0xc8afd8683afdece6 => 72
	i64 14464374589798375073, ; 481: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 309
	i64 14486659737292545672, ; 482: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 239
	i64 14491877563792607819, ; 483: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0xc91d7ddcee4fca4b => 317
	i64 14495724990987328804, ; 484: Xamarin.AndroidX.ResourceInspection.Annotation => 0xc92b2913e18d5d24 => 257
	i64 14551742072151931844, ; 485: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 136
	i64 14556034074661724008, ; 486: CommunityToolkit.Maui.Core => 0xca016bdea6b19f68 => 174
	i64 14561513370130550166, ; 487: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 124
	i64 14574160591280636898, ; 488: System.Net.Quic => 0xca41d1d72ec783e2 => 71
	i64 14610046442689856844, ; 489: cs\Microsoft.Maui.Controls.resources.dll => 0xcac14fd5107d054c => 287
	i64 14622043554576106986, ; 490: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 111
	i64 14644440854989303794, ; 491: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 249
	i64 14669215534098758659, ; 492: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 184
	i64 14690985099581930927, ; 493: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 152
	i64 14705122255218365489, ; 494: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 301
	i64 14735017007120366644, ; 495: ja\Microsoft.Maui.Controls.resources.dll => 0xcc7d4be604bfbc34 => 300
	i64 14744092281598614090, ; 496: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 317
	i64 14792063746108907174, ; 497: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 277
	i64 14832630590065248058, ; 498: System.Security.Claims => 0xcdd816ef5d6e873a => 118
	i64 14852515768018889994, ; 499: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 225
	i64 14878846463457333868, ; 500: ChefManager => 0xce7c4806e9f3926c => 0
	i64 14889905118082851278, ; 501: GoogleGson.dll => 0xcea391d0969961ce => 179
	i64 14904040806490515477, ; 502: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 285
	i64 14912225920358050525, ; 503: System.Security.Principal.Windows => 0xcef2de7759506add => 127
	i64 14935719434541007538, ; 504: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 133
	i64 14954917835170835695, ; 505: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 185
	i64 14984936317414011727, ; 506: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 77
	i64 14987728460634540364, ; 507: System.IO.Compression.dll => 0xcfff1ba06622494c => 46
	i64 14988210264188246988, ; 508: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 228
	i64 15015154896917945444, ; 509: System.Net.Security.dll => 0xd0608bd33642dc64 => 73
	i64 15024878362326791334, ; 510: System.Net.Http.Json => 0xd0831743ebf0f4a6 => 63
	i64 15037088180954523232, ; 511: System.Net.Http.Extensions.dll => 0xd0ae7807da04e660 => 197
	i64 15071021337266399595, ; 512: System.Resources.Reader.dll => 0xd127060e7a18a96b => 98
	i64 15076659072870671916, ; 513: System.ObjectModel.dll => 0xd13b0d8c1620662c => 84
	i64 15082578449315132289, ; 514: Plugin.Maui.Calendar => 0xd15015305063f381 => 200
	i64 15111608613780139878, ; 515: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 302
	i64 15115185479366240210, ; 516: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 43
	i64 15133318570858120619, ; 517: System.Net.Http.Primitives.dll => 0xd204590f78d205ab => 198
	i64 15133485256822086103, ; 518: System.Linq.dll => 0xd204f0a9127dd9d7 => 61
	i64 15150743910298169673, ; 519: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xd2424150783c3149 => 255
	i64 15203009853192377507, ; 520: pt\Microsoft.Maui.Controls.resources.dll => 0xd2fbf0e9984b94a3 => 307
	i64 15227001540531775957, ; 521: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 183
	i64 15234786388537674379, ; 522: System.Dynamic.Runtime.dll => 0xd36cd580c5be8a8b => 37
	i64 15250465174479574862, ; 523: System.Globalization.Calendars.dll => 0xd3a489469852174e => 40
	i64 15272359115529052076, ; 524: Xamarin.AndroidX.Collection.Ktx => 0xd3f251b2fb4edfac => 218
	i64 15279429628684179188, ; 525: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 283
	i64 15299439993936780255, ; 526: System.Xml.XPath.dll => 0xd452879d55019bdf => 160
	i64 15338463749992804988, ; 527: System.Resources.Reader => 0xd4dd2b839286f27c => 98
	i64 15370334346939861994, ; 528: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 223
	i64 15391712275433856905, ; 529: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 185
	i64 15526743539506359484, ; 530: System.Text.Encoding.dll => 0xd77a12fc26de2cbc => 135
	i64 15527772828719725935, ; 531: System.Console => 0xd77dbb1e38cd3d6f => 20
	i64 15530465045505749832, ; 532: System.Net.HttpListener.dll => 0xd7874bacc9fdb348 => 65
	i64 15536481058354060254, ; 533: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 289
	i64 15541854775306130054, ; 534: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 125
	i64 15557562860424774966, ; 535: System.Net.Sockets => 0xd7e790fe7a6dc536 => 75
	i64 15559045586289472399, ; 536: Microsoft.Threading.Tasks.Extensions => 0xd7ecd5867ee4b38f => 180
	i64 15582737692548360875, ; 537: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 247
	i64 15609085926864131306, ; 538: System.dll => 0xd89e9cf3334914ea => 164
	i64 15661133872274321916, ; 539: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 156
	i64 15710114879900314733, ; 540: Microsoft.Win32.Registry => 0xda058a3f5d096c6d => 5
	i64 15755368083429170162, ; 541: System.IO.FileSystem.Primitives => 0xdaa64fcbde529bf2 => 49
	i64 15777549416145007739, ; 542: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 261
	i64 15783653065526199428, ; 543: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 290
	i64 15817206913877585035, ; 544: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 144
	i64 15847085070278954535, ; 545: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 139
	i64 15885744048853936810, ; 546: System.Resources.Writer => 0xdc75800bd0b6eaaa => 100
	i64 15903132883471575892, ; 547: ChefManager.dll => 0xdcb347195f282b54 => 0
	i64 15928521404965645318, ; 548: Microsoft.Maui.Controls.Compatibility => 0xdd0d79d32c2eec06 => 191
	i64 15934062614519587357, ; 549: System.Security.Cryptography.OpenSsl => 0xdd2129868f45a21d => 123
	i64 15937190497610202713, ; 550: System.Security.Cryptography.Cng => 0xdd2c465197c97e59 => 120
	i64 15963349826457351533, ; 551: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 142
	i64 15971679995444160383, ; 552: System.Formats.Tar.dll => 0xdda6ce5592a9677f => 39
	i64 15987609494471769098, ; 553: Firebase.Storage => 0xdddf662115a6fc0a => 177
	i64 16018552496348375205, ; 554: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 68
	i64 16054465462676478687, ; 555: System.Globalization.Extensions => 0xdecceb47319bdadf => 41
	i64 16056281320585338352, ; 556: ru\Microsoft.Maui.Controls.resources.dll => 0xded35eca8f3a9df0 => 309
	i64 16154507427712707110, ; 557: System => 0xe03056ea4e39aa26 => 164
	i64 16219561732052121626, ; 558: System.Net.Security => 0xe1177575db7c781a => 73
	i64 16288847719894691167, ; 559: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 303
	i64 16315482530584035869, ; 560: WindowsBase.dll => 0xe26c3ceb1e8d821d => 165
	i64 16321164108206115771, ; 561: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 187
	i64 16337011941688632206, ; 562: System.Security.Principal.Windows.dll => 0xe2b8b9cdc3aa638e => 127
	i64 16361933716545543812, ; 563: Xamarin.AndroidX.ExifInterface.dll => 0xe3114406a52f1e84 => 233
	i64 16423015068819898779, ; 564: Xamarin.Kotlin.StdLib.Jdk8 => 0xe3ea453135e5c19b => 282
	i64 16454459195343277943, ; 565: System.Net.NetworkInformation => 0xe459fb756d988f77 => 68
	i64 16496768397145114574, ; 566: Mono.Android.Export.dll => 0xe4f04b741db987ce => 169
	i64 16589693266713801121, ; 567: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xe63a6e214f2a71a1 => 246
	i64 16621146507174665210, ; 568: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 220
	i64 16648892297579399389, ; 569: CommunityToolkit.Mvvm => 0xe70cbf55c4f508dd => 175
	i64 16649148416072044166, ; 570: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 196
	i64 16677317093839702854, ; 571: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 253
	i64 16702652415771857902, ; 572: System.ValueTuple => 0xe7cbbde0b0e6d3ee => 151
	i64 16709499819875633724, ; 573: System.IO.Compression.ZipFile => 0xe7e4118e32240a3c => 45
	i64 16737807731308835127, ; 574: System.Runtime.Intrinsics => 0xe848a3736f733137 => 108
	i64 16758309481308491337, ; 575: System.IO.FileSystem.DriveInfo => 0xe89179af15740e49 => 48
	i64 16762783179241323229, ; 576: System.Reflection.TypeExtensions => 0xe8a15e7d0d927add => 96
	i64 16765015072123548030, ; 577: System.Diagnostics.TextWriterTraceListener.dll => 0xe8a94c621bfe717e => 31
	i64 16803648858859583026, ; 578: ms\Microsoft.Maui.Controls.resources.dll => 0xe9328d9b8ab93632 => 302
	i64 16822611501064131242, ; 579: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 23
	i64 16833383113903931215, ; 580: mscorlib => 0xe99c30c1484d7f4f => 166
	i64 16856067890322379635, ; 581: System.Data.Common.dll => 0xe9ecc87060889373 => 22
	i64 16890310621557459193, ; 582: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 138
	i64 16933958494752847024, ; 583: System.Net.WebProxy.dll => 0xeb018187f0f3b4b0 => 78
	i64 16942731696432749159, ; 584: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 310
	i64 16977952268158210142, ; 585: System.IO.Pipes.AccessControl => 0xeb9dcda2851b905e => 54
	i64 16989020923549080504, ; 586: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xebc52084add25bb8 => 246
	i64 16998075588627545693, ; 587: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 251
	i64 17008137082415910100, ; 588: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 10
	i64 17024911836938395553, ; 589: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 209
	i64 17031351772568316411, ; 590: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 250
	i64 17037200463775726619, ; 591: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 237
	i64 17062143951396181894, ; 592: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 16
	i64 17118171214553292978, ; 593: System.Threading.Channels => 0xed8ff6060fc420b2 => 139
	i64 17187273293601214786, ; 594: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 13
	i64 17201328579425343169, ; 595: System.ComponentModel.EventBasedAsync => 0xeeb76534d96c16c1 => 15
	i64 17202182880784296190, ; 596: System.Security.Cryptography.Encoding.dll => 0xeeba6e30627428fe => 122
	i64 17203614576212522419, ; 597: pl\Microsoft.Maui.Controls.resources.dll => 0xeebf844ef3e135b3 => 305
	i64 17230721278011714856, ; 598: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 87
	i64 17234219099804750107, ; 599: System.Transactions.Local.dll => 0xef2c3ef5e11d511b => 149
	i64 17260702271250283638, ; 600: System.Data.Common => 0xef8a5543bba6bc76 => 22
	i64 17310278548634113468, ; 601: hi\Microsoft.Maui.Controls.resources.dll => 0xf03a76a04e6695bc => 295
	i64 17333249706306540043, ; 602: System.Diagnostics.Tracing.dll => 0xf08c12c5bb8b920b => 34
	i64 17338386382517543202, ; 603: System.Net.WebSockets.Client.dll => 0xf09e528d5c6da122 => 79
	i64 17342750010158924305, ; 604: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 295
	i64 17360349973592121190, ; 605: Xamarin.Google.Crypto.Tink.Android => 0xf0ec5a52686b9f66 => 275
	i64 17470386307322966175, ; 606: System.Threading.Timer => 0xf27347c8d0d5709f => 147
	i64 17509662556995089465, ; 607: System.Net.WebSockets.dll => 0xf2fed1534ea67439 => 80
	i64 17514990004910432069, ; 608: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 293
	i64 17522591619082469157, ; 609: GoogleGson => 0xf32cc03d27a5bf25 => 179
	i64 17590473451926037903, ; 610: Xamarin.Android.Glide => 0xf41dea67fcfda58f => 202
	i64 17623389608345532001, ; 611: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 305
	i64 17627500474728259406, ; 612: System.Globalization => 0xf4a176498a351f4e => 42
	i64 17685921127322830888, ; 613: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 26
	i64 17704177640604968747, ; 614: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 248
	i64 17710060891934109755, ; 615: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 245
	i64 17712670374920797664, ; 616: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 107
	i64 17777860260071588075, ; 617: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 110
	i64 17827813215687577648, ; 618: hr\Microsoft.Maui.Controls.resources.dll => 0xf7691da9f3129030 => 296
	i64 17838668724098252521, ; 619: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 7
	i64 17891337867145587222, ; 620: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 278
	i64 17928294245072900555, ; 621: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 44
	i64 17942426894774770628, ; 622: de\Microsoft.Maui.Controls.resources.dll => 0xf9004e329f771bc4 => 289
	i64 17992315986609351877, ; 623: System.Xml.XmlDocument.dll => 0xf9b18c0ffc6eacc5 => 161
	i64 18025913125965088385, ; 624: System.Threading => 0xfa28e87b91334681 => 148
	i64 18116111925905154859, ; 625: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 214
	i64 18121036031235206392, ; 626: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 250
	i64 18146411883821974900, ; 627: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 38
	i64 18146811631844267958, ; 628: System.ComponentModel.EventBasedAsync.dll => 0xfbd66d08820117b6 => 15
	i64 18225059387460068507, ; 629: System.Threading.ThreadPool.dll => 0xfcec6af3cff4a49b => 146
	i64 18245806341561545090, ; 630: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 8
	i64 18260797123374478311, ; 631: Xamarin.AndroidX.Emoji2 => 0xfd6b623bde35f3e7 => 231
	i64 18305135509493619199, ; 632: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 252
	i64 18318849532986632368, ; 633: System.Security.dll => 0xfe39a097c37fa8b0 => 130
	i64 18324163916253801303, ; 634: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 299
	i64 18342408478508122430, ; 635: id\Microsoft.Maui.Controls.resources.dll => 0xfe8d53543697013e => 298
	i64 18358161419737137786, ; 636: he\Microsoft.Maui.Controls.resources.dll => 0xfec54a8ba8b6827a => 294
	i64 18380184030268848184, ; 637: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 268
	i64 18439108438687598470, ; 638: System.Reflection.Metadata.dll => 0xffe4df6e2ee1c786 => 94
	i64 18442939251584021150 ; 639: FireSharp => 0xfff27b88d0c6329e => 178
], align 16

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [640 x i32] [
	i32 230, ; 0
	i32 190, ; 1
	i32 171, ; 2
	i32 195, ; 3
	i32 58, ; 4
	i32 217, ; 5
	i32 151, ; 6
	i32 258, ; 7
	i32 261, ; 8
	i32 224, ; 9
	i32 132, ; 10
	i32 56, ; 11
	i32 260, ; 12
	i32 95, ; 13
	i32 243, ; 14
	i32 129, ; 15
	i32 145, ; 16
	i32 218, ; 17
	i32 18, ; 18
	i32 297, ; 19
	i32 229, ; 20
	i32 244, ; 21
	i32 150, ; 22
	i32 104, ; 23
	i32 198, ; 24
	i32 95, ; 25
	i32 273, ; 26
	i32 36, ; 27
	i32 28, ; 28
	i32 213, ; 29
	i32 251, ; 30
	i32 50, ; 31
	i32 115, ; 32
	i32 70, ; 33
	i32 192, ; 34
	i32 65, ; 35
	i32 170, ; 36
	i32 145, ; 37
	i32 272, ; 38
	i32 212, ; 39
	i32 247, ; 40
	i32 237, ; 41
	i32 40, ; 42
	i32 89, ; 43
	i32 81, ; 44
	i32 180, ; 45
	i32 199, ; 46
	i32 66, ; 47
	i32 62, ; 48
	i32 86, ; 49
	i32 211, ; 50
	i32 106, ; 51
	i32 291, ; 52
	i32 258, ; 53
	i32 102, ; 54
	i32 35, ; 55
	i32 208, ; 56
	i32 313, ; 57
	i32 260, ; 58
	i32 193, ; 59
	i32 175, ; 60
	i32 119, ; 61
	i32 245, ; 62
	i32 142, ; 63
	i32 141, ; 64
	i32 281, ; 65
	i32 53, ; 66
	i32 35, ; 67
	i32 141, ; 68
	i32 199, ; 69
	i32 205, ; 70
	i32 215, ; 71
	i32 188, ; 72
	i32 229, ; 73
	i32 8, ; 74
	i32 14, ; 75
	i32 257, ; 76
	i32 51, ; 77
	i32 240, ; 78
	i32 136, ; 79
	i32 101, ; 80
	i32 222, ; 81
	i32 267, ; 82
	i32 116, ; 83
	i32 206, ; 84
	i32 163, ; 85
	i32 312, ; 86
	i32 166, ; 87
	i32 67, ; 88
	i32 184, ; 89
	i32 287, ; 90
	i32 80, ; 91
	i32 101, ; 92
	i32 262, ; 93
	i32 117, ; 94
	i32 292, ; 95
	i32 274, ; 96
	i32 78, ; 97
	i32 273, ; 98
	i32 114, ; 99
	i32 121, ; 100
	i32 48, ; 101
	i32 128, ; 102
	i32 238, ; 103
	i32 209, ; 104
	i32 82, ; 105
	i32 110, ; 106
	i32 75, ; 107
	i32 284, ; 108
	i32 195, ; 109
	i32 53, ; 110
	i32 264, ; 111
	i32 182, ; 112
	i32 69, ; 113
	i32 263, ; 114
	i32 83, ; 115
	i32 172, ; 116
	i32 307, ; 117
	i32 116, ; 118
	i32 183, ; 119
	i32 156, ; 120
	i32 182, ; 121
	i32 203, ; 122
	i32 167, ; 123
	i32 256, ; 124
	i32 230, ; 125
	i32 186, ; 126
	i32 32, ; 127
	i32 193, ; 128
	i32 122, ; 129
	i32 72, ; 130
	i32 62, ; 131
	i32 161, ; 132
	i32 113, ; 133
	i32 288, ; 134
	i32 88, ; 135
	i32 191, ; 136
	i32 318, ; 137
	i32 105, ; 138
	i32 18, ; 139
	i32 146, ; 140
	i32 118, ; 141
	i32 58, ; 142
	i32 224, ; 143
	i32 17, ; 144
	i32 52, ; 145
	i32 92, ; 146
	i32 313, ; 147
	i32 55, ; 148
	i32 178, ; 149
	i32 129, ; 150
	i32 152, ; 151
	i32 41, ; 152
	i32 92, ; 153
	i32 268, ; 154
	i32 50, ; 155
	i32 162, ; 156
	i32 13, ; 157
	i32 242, ; 158
	i32 206, ; 159
	i32 263, ; 160
	i32 36, ; 161
	i32 67, ; 162
	i32 109, ; 163
	i32 303, ; 164
	i32 311, ; 165
	i32 207, ; 166
	i32 99, ; 167
	i32 99, ; 168
	i32 11, ; 169
	i32 11, ; 170
	i32 201, ; 171
	i32 249, ; 172
	i32 25, ; 173
	i32 128, ; 174
	i32 76, ; 175
	i32 241, ; 176
	i32 109, ; 177
	i32 267, ; 178
	i32 265, ; 179
	i32 106, ; 180
	i32 2, ; 181
	i32 26, ; 182
	i32 220, ; 183
	i32 157, ; 184
	i32 311, ; 185
	i32 21, ; 186
	i32 314, ; 187
	i32 49, ; 188
	i32 43, ; 189
	i32 126, ; 190
	i32 210, ; 191
	i32 59, ; 192
	i32 119, ; 193
	i32 270, ; 194
	i32 233, ; 195
	i32 219, ; 196
	i32 3, ; 197
	i32 239, ; 198
	i32 259, ; 199
	i32 38, ; 200
	i32 124, ; 201
	i32 259, ; 202
	i32 308, ; 203
	i32 176, ; 204
	i32 137, ; 205
	i32 149, ; 206
	i32 85, ; 207
	i32 90, ; 208
	i32 291, ; 209
	i32 243, ; 210
	i32 319, ; 211
	i32 240, ; 212
	i32 292, ; 213
	i32 296, ; 214
	i32 215, ; 215
	i32 226, ; 216
	i32 271, ; 217
	i32 189, ; 218
	i32 276, ; 219
	i32 241, ; 220
	i32 133, ; 221
	i32 96, ; 222
	i32 3, ; 223
	i32 304, ; 224
	i32 105, ; 225
	i32 33, ; 226
	i32 154, ; 227
	i32 158, ; 228
	i32 155, ; 229
	i32 200, ; 230
	i32 82, ; 231
	i32 235, ; 232
	i32 143, ; 233
	i32 87, ; 234
	i32 19, ; 235
	i32 236, ; 236
	i32 51, ; 237
	i32 205, ; 238
	i32 61, ; 239
	i32 54, ; 240
	i32 4, ; 241
	i32 97, ; 242
	i32 204, ; 243
	i32 17, ; 244
	i32 155, ; 245
	i32 84, ; 246
	i32 29, ; 247
	i32 45, ; 248
	i32 64, ; 249
	i32 66, ; 250
	i32 172, ; 251
	i32 244, ; 252
	i32 1, ; 253
	i32 279, ; 254
	i32 299, ; 255
	i32 47, ; 256
	i32 24, ; 257
	i32 212, ; 258
	i32 310, ; 259
	i32 165, ; 260
	i32 108, ; 261
	i32 12, ; 262
	i32 238, ; 263
	i32 63, ; 264
	i32 27, ; 265
	i32 23, ; 266
	i32 301, ; 267
	i32 93, ; 268
	i32 168, ; 269
	i32 12, ; 270
	i32 283, ; 271
	i32 177, ; 272
	i32 196, ; 273
	i32 29, ; 274
	i32 103, ; 275
	i32 14, ; 276
	i32 126, ; 277
	i32 316, ; 278
	i32 221, ; 279
	i32 253, ; 280
	i32 91, ; 281
	i32 242, ; 282
	i32 9, ; 283
	i32 86, ; 284
	i32 232, ; 285
	i32 173, ; 286
	i32 265, ; 287
	i32 71, ; 288
	i32 168, ; 289
	i32 1, ; 290
	i32 252, ; 291
	i32 5, ; 292
	i32 306, ; 293
	i32 44, ; 294
	i32 27, ; 295
	i32 181, ; 296
	i32 280, ; 297
	i32 158, ; 298
	i32 255, ; 299
	i32 112, ; 300
	i32 316, ; 301
	i32 197, ; 302
	i32 121, ; 303
	i32 181, ; 304
	i32 270, ; 305
	i32 211, ; 306
	i32 290, ; 307
	i32 159, ; 308
	i32 314, ; 309
	i32 131, ; 310
	i32 275, ; 311
	i32 57, ; 312
	i32 138, ; 313
	i32 83, ; 314
	i32 30, ; 315
	i32 222, ; 316
	i32 10, ; 317
	i32 286, ; 318
	i32 272, ; 319
	i32 171, ; 320
	i32 219, ; 321
	i32 150, ; 322
	i32 94, ; 323
	i32 232, ; 324
	i32 60, ; 325
	i32 194, ; 326
	i32 157, ; 327
	i32 188, ; 328
	i32 64, ; 329
	i32 88, ; 330
	i32 79, ; 331
	i32 47, ; 332
	i32 192, ; 333
	i32 143, ; 334
	i32 288, ; 335
	i32 304, ; 336
	i32 281, ; 337
	i32 226, ; 338
	i32 74, ; 339
	i32 91, ; 340
	i32 278, ; 341
	i32 135, ; 342
	i32 90, ; 343
	i32 264, ; 344
	i32 284, ; 345
	i32 223, ; 346
	i32 286, ; 347
	i32 112, ; 348
	i32 42, ; 349
	i32 159, ; 350
	i32 4, ; 351
	i32 103, ; 352
	i32 318, ; 353
	i32 70, ; 354
	i32 60, ; 355
	i32 39, ; 356
	i32 213, ; 357
	i32 173, ; 358
	i32 153, ; 359
	i32 56, ; 360
	i32 34, ; 361
	i32 187, ; 362
	i32 194, ; 363
	i32 210, ; 364
	i32 21, ; 365
	i32 163, ; 366
	i32 276, ; 367
	i32 297, ; 368
	i32 274, ; 369
	i32 312, ; 370
	i32 293, ; 371
	i32 269, ; 372
	i32 140, ; 373
	i32 300, ; 374
	i32 189, ; 375
	i32 89, ; 376
	i32 147, ; 377
	i32 225, ; 378
	i32 162, ; 379
	i32 254, ; 380
	i32 6, ; 381
	i32 169, ; 382
	i32 31, ; 383
	i32 107, ; 384
	i32 235, ; 385
	i32 298, ; 386
	i32 269, ; 387
	i32 186, ; 388
	i32 208, ; 389
	i32 262, ; 390
	i32 167, ; 391
	i32 236, ; 392
	i32 140, ; 393
	i32 59, ; 394
	i32 144, ; 395
	i32 315, ; 396
	i32 81, ; 397
	i32 74, ; 398
	i32 130, ; 399
	i32 25, ; 400
	i32 7, ; 401
	i32 93, ; 402
	i32 266, ; 403
	i32 137, ; 404
	i32 202, ; 405
	i32 113, ; 406
	i32 9, ; 407
	i32 104, ; 408
	i32 174, ; 409
	i32 19, ; 410
	i32 234, ; 411
	i32 248, ; 412
	i32 319, ; 413
	i32 228, ; 414
	i32 33, ; 415
	i32 176, ; 416
	i32 216, ; 417
	i32 46, ; 418
	i32 30, ; 419
	i32 217, ; 420
	i32 57, ; 421
	i32 134, ; 422
	i32 114, ; 423
	i32 271, ; 424
	i32 282, ; 425
	i32 55, ; 426
	i32 190, ; 427
	i32 6, ; 428
	i32 77, ; 429
	i32 227, ; 430
	i32 285, ; 431
	i32 306, ; 432
	i32 111, ; 433
	i32 231, ; 434
	i32 102, ; 435
	i32 170, ; 436
	i32 115, ; 437
	i32 294, ; 438
	i32 266, ; 439
	i32 221, ; 440
	i32 76, ; 441
	i32 277, ; 442
	i32 85, ; 443
	i32 279, ; 444
	i32 214, ; 445
	i32 315, ; 446
	i32 256, ; 447
	i32 160, ; 448
	i32 2, ; 449
	i32 227, ; 450
	i32 201, ; 451
	i32 24, ; 452
	i32 207, ; 453
	i32 32, ; 454
	i32 117, ; 455
	i32 37, ; 456
	i32 16, ; 457
	i32 52, ; 458
	i32 280, ; 459
	i32 20, ; 460
	i32 123, ; 461
	i32 154, ; 462
	i32 234, ; 463
	i32 131, ; 464
	i32 216, ; 465
	i32 148, ; 466
	i32 203, ; 467
	i32 120, ; 468
	i32 28, ; 469
	i32 132, ; 470
	i32 100, ; 471
	i32 134, ; 472
	i32 254, ; 473
	i32 153, ; 474
	i32 97, ; 475
	i32 125, ; 476
	i32 204, ; 477
	i32 69, ; 478
	i32 308, ; 479
	i32 72, ; 480
	i32 309, ; 481
	i32 239, ; 482
	i32 317, ; 483
	i32 257, ; 484
	i32 136, ; 485
	i32 174, ; 486
	i32 124, ; 487
	i32 71, ; 488
	i32 287, ; 489
	i32 111, ; 490
	i32 249, ; 491
	i32 184, ; 492
	i32 152, ; 493
	i32 301, ; 494
	i32 300, ; 495
	i32 317, ; 496
	i32 277, ; 497
	i32 118, ; 498
	i32 225, ; 499
	i32 0, ; 500
	i32 179, ; 501
	i32 285, ; 502
	i32 127, ; 503
	i32 133, ; 504
	i32 185, ; 505
	i32 77, ; 506
	i32 46, ; 507
	i32 228, ; 508
	i32 73, ; 509
	i32 63, ; 510
	i32 197, ; 511
	i32 98, ; 512
	i32 84, ; 513
	i32 200, ; 514
	i32 302, ; 515
	i32 43, ; 516
	i32 198, ; 517
	i32 61, ; 518
	i32 255, ; 519
	i32 307, ; 520
	i32 183, ; 521
	i32 37, ; 522
	i32 40, ; 523
	i32 218, ; 524
	i32 283, ; 525
	i32 160, ; 526
	i32 98, ; 527
	i32 223, ; 528
	i32 185, ; 529
	i32 135, ; 530
	i32 20, ; 531
	i32 65, ; 532
	i32 289, ; 533
	i32 125, ; 534
	i32 75, ; 535
	i32 180, ; 536
	i32 247, ; 537
	i32 164, ; 538
	i32 156, ; 539
	i32 5, ; 540
	i32 49, ; 541
	i32 261, ; 542
	i32 290, ; 543
	i32 144, ; 544
	i32 139, ; 545
	i32 100, ; 546
	i32 0, ; 547
	i32 191, ; 548
	i32 123, ; 549
	i32 120, ; 550
	i32 142, ; 551
	i32 39, ; 552
	i32 177, ; 553
	i32 68, ; 554
	i32 41, ; 555
	i32 309, ; 556
	i32 164, ; 557
	i32 73, ; 558
	i32 303, ; 559
	i32 165, ; 560
	i32 187, ; 561
	i32 127, ; 562
	i32 233, ; 563
	i32 282, ; 564
	i32 68, ; 565
	i32 169, ; 566
	i32 246, ; 567
	i32 220, ; 568
	i32 175, ; 569
	i32 196, ; 570
	i32 253, ; 571
	i32 151, ; 572
	i32 45, ; 573
	i32 108, ; 574
	i32 48, ; 575
	i32 96, ; 576
	i32 31, ; 577
	i32 302, ; 578
	i32 23, ; 579
	i32 166, ; 580
	i32 22, ; 581
	i32 138, ; 582
	i32 78, ; 583
	i32 310, ; 584
	i32 54, ; 585
	i32 246, ; 586
	i32 251, ; 587
	i32 10, ; 588
	i32 209, ; 589
	i32 250, ; 590
	i32 237, ; 591
	i32 16, ; 592
	i32 139, ; 593
	i32 13, ; 594
	i32 15, ; 595
	i32 122, ; 596
	i32 305, ; 597
	i32 87, ; 598
	i32 149, ; 599
	i32 22, ; 600
	i32 295, ; 601
	i32 34, ; 602
	i32 79, ; 603
	i32 295, ; 604
	i32 275, ; 605
	i32 147, ; 606
	i32 80, ; 607
	i32 293, ; 608
	i32 179, ; 609
	i32 202, ; 610
	i32 305, ; 611
	i32 42, ; 612
	i32 26, ; 613
	i32 248, ; 614
	i32 245, ; 615
	i32 107, ; 616
	i32 110, ; 617
	i32 296, ; 618
	i32 7, ; 619
	i32 278, ; 620
	i32 44, ; 621
	i32 289, ; 622
	i32 161, ; 623
	i32 148, ; 624
	i32 214, ; 625
	i32 250, ; 626
	i32 38, ; 627
	i32 15, ; 628
	i32 146, ; 629
	i32 8, ; 630
	i32 231, ; 631
	i32 252, ; 632
	i32 130, ; 633
	i32 299, ; 634
	i32 298, ; 635
	i32 294, ; 636
	i32 268, ; 637
	i32 94, ; 638
	i32 178 ; 639
], align 16

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 16

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}