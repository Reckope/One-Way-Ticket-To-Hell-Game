template <typename T> void RegisterClass();
template <typename T> void RegisterStrippedType(int, const char*, const char*);

void InvokeRegisterStaticallyLinkedModuleClasses()
{
	// Do nothing (we're in stripping mode)
}

void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_CloudWebServices();
	RegisterModule_CloudWebServices();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_UnityConnect();
	RegisterModule_UnityConnect();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_GameCenter();
	RegisterModule_GameCenter();

	void RegisterModule_Core();
	RegisterModule_Core();

	void RegisterModule_SharedInternals();
	RegisterModule_SharedInternals();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

	void RegisterModule_UnityWebRequest();
	RegisterModule_UnityWebRequest();

	void RegisterModule_ImageConversion();
	RegisterModule_ImageConversion();

}

class EditorExtension; template <> void RegisterClass<EditorExtension>();
namespace Unity { class Component; } template <> void RegisterClass<Unity::Component>();
class Behaviour; template <> void RegisterClass<Behaviour>();
class Animation; 
class Animator; template <> void RegisterClass<Animator>();
class AudioBehaviour; template <> void RegisterClass<AudioBehaviour>();
class AudioListener; template <> void RegisterClass<AudioListener>();
class AudioSource; template <> void RegisterClass<AudioSource>();
class AudioFilter; 
class AudioChorusFilter; 
class AudioDistortionFilter; 
class AudioEchoFilter; 
class AudioHighPassFilter; 
class AudioLowPassFilter; 
class AudioReverbFilter; 
class AudioReverbZone; 
class Camera; template <> void RegisterClass<Camera>();
namespace UI { class Canvas; } template <> void RegisterClass<UI::Canvas>();
namespace UI { class CanvasGroup; } template <> void RegisterClass<UI::CanvasGroup>();
namespace Unity { class Cloth; } 
class Collider2D; template <> void RegisterClass<Collider2D>();
class BoxCollider2D; template <> void RegisterClass<BoxCollider2D>();
class CapsuleCollider2D; template <> void RegisterClass<CapsuleCollider2D>();
class CircleCollider2D; template <> void RegisterClass<CircleCollider2D>();
class CompositeCollider2D; 
class EdgeCollider2D; 
class PolygonCollider2D; template <> void RegisterClass<PolygonCollider2D>();
class TilemapCollider2D; 
class ConstantForce; 
class Effector2D; template <> void RegisterClass<Effector2D>();
class AreaEffector2D; 
class BuoyancyEffector2D; 
class PlatformEffector2D; template <> void RegisterClass<PlatformEffector2D>();
class PointEffector2D; 
class SurfaceEffector2D; 
class FlareLayer; template <> void RegisterClass<FlareLayer>();
class GUIElement; template <> void RegisterClass<GUIElement>();
namespace TextRenderingPrivate { class GUIText; } 
class GUITexture; 
class GUILayer; template <> void RegisterClass<GUILayer>();
class GridLayout; 
class Grid; 
class Tilemap; 
class Halo; 
class HaloLayer; 
class Joint2D; 
class AnchoredJoint2D; 
class DistanceJoint2D; 
class FixedJoint2D; 
class FrictionJoint2D; 
class HingeJoint2D; 
class SliderJoint2D; 
class SpringJoint2D; 
class WheelJoint2D; 
class RelativeJoint2D; 
class TargetJoint2D; 
class LensFlare; 
class Light; 
class LightProbeGroup; 
class LightProbeProxyVolume; 
class MonoBehaviour; template <> void RegisterClass<MonoBehaviour>();
class NavMeshAgent; 
class NavMeshObstacle; 
class NetworkView; 
class OffMeshLink; 
class PhysicsUpdateBehaviour2D; 
class ConstantForce2D; 
class PlayableDirector; 
class Projector; 
class ReflectionProbe; 
class Skybox; 
class SortingGroup; 
class Terrain; 
class VideoPlayer; 
class WindZone; 
namespace UI { class CanvasRenderer; } template <> void RegisterClass<UI::CanvasRenderer>();
class Collider; 
class BoxCollider; 
class CapsuleCollider; 
class CharacterController; 
class MeshCollider; 
class SphereCollider; 
class TerrainCollider; 
class WheelCollider; 
namespace Unity { class Joint; } 
namespace Unity { class CharacterJoint; } 
namespace Unity { class ConfigurableJoint; } 
namespace Unity { class FixedJoint; } 
namespace Unity { class HingeJoint; } 
namespace Unity { class SpringJoint; } 
class LODGroup; 
class MeshFilter; template <> void RegisterClass<MeshFilter>();
class OcclusionArea; 
class OcclusionPortal; 
class ParticleAnimator; 
class ParticleEmitter; 
class EllipsoidParticleEmitter; 
class MeshParticleEmitter; 
class ParticleSystem; 
class Renderer; template <> void RegisterClass<Renderer>();
class BillboardRenderer; 
class LineRenderer; 
class MeshRenderer; template <> void RegisterClass<MeshRenderer>();
class ParticleRenderer; 
class ParticleSystemRenderer; 
class SkinnedMeshRenderer; 
class SpriteMask; 
class SpriteRenderer; template <> void RegisterClass<SpriteRenderer>();
class TilemapRenderer; 
class TrailRenderer; 
class Rigidbody; 
class Rigidbody2D; template <> void RegisterClass<Rigidbody2D>();
namespace TextRenderingPrivate { class TextMesh; } 
class Transform; template <> void RegisterClass<Transform>();
namespace UI { class RectTransform; } template <> void RegisterClass<UI::RectTransform>();
class Tree; 
class WorldAnchor; 
class WorldParticleCollider; 
class GameObject; template <> void RegisterClass<GameObject>();
class NamedObject; template <> void RegisterClass<NamedObject>();
class AssetBundle; 
class AssetBundleManifest; 
class ScriptedImporter; 
class AudioMixer; 
class AudioMixerController; 
class AudioMixerGroup; 
class AudioMixerGroupController; 
class AudioMixerSnapshot; 
class AudioMixerSnapshotController; 
class Avatar; 
class AvatarMask; 
class BillboardAsset; 
class ComputeShader; 
class Flare; 
namespace TextRendering { class Font; } template <> void RegisterClass<TextRendering::Font>();
class GameObjectRecorder; 
class LightProbes; 
class Material; template <> void RegisterClass<Material>();
class ProceduralMaterial; 
class Mesh; template <> void RegisterClass<Mesh>();
class Motion; 
class AnimationClip; 
class PreviewAnimationClip; 
class NavMeshData; 
class OcclusionCullingData; 
class PhysicMaterial; 
class PhysicsMaterial2D; template <> void RegisterClass<PhysicsMaterial2D>();
class PreloadData; template <> void RegisterClass<PreloadData>();
class RuntimeAnimatorController; 
class AnimatorController; 
class AnimatorOverrideController; 
class SampleClip; template <> void RegisterClass<SampleClip>();
class AudioClip; template <> void RegisterClass<AudioClip>();
class Shader; template <> void RegisterClass<Shader>();
class ShaderVariantCollection; 
class SpeedTreeWindAsset; 
class Sprite; template <> void RegisterClass<Sprite>();
class SpriteAtlas; 
class SubstanceArchive; 
class TerrainData; 
class TextAsset; template <> void RegisterClass<TextAsset>();
class CGProgram; 
class MonoScript; template <> void RegisterClass<MonoScript>();
class Texture; template <> void RegisterClass<Texture>();
class BaseVideoTexture; 
class MovieTexture; 
class WebCamTexture; 
class CubemapArray; 
class LowerResBlitTexture; template <> void RegisterClass<LowerResBlitTexture>();
class ProceduralTexture; 
class RenderTexture; template <> void RegisterClass<RenderTexture>();
class CustomRenderTexture; 
class SparseTexture; 
class Texture2D; template <> void RegisterClass<Texture2D>();
class Cubemap; template <> void RegisterClass<Cubemap>();
class Texture2DArray; template <> void RegisterClass<Texture2DArray>();
class Texture3D; template <> void RegisterClass<Texture3D>();
class VideoClip; 
class GameManager; template <> void RegisterClass<GameManager>();
class GlobalGameManager; template <> void RegisterClass<GlobalGameManager>();
class AudioManager; template <> void RegisterClass<AudioManager>();
class BuildSettings; template <> void RegisterClass<BuildSettings>();
class CloudWebServicesManager; template <> void RegisterClass<CloudWebServicesManager>();
class CrashReportManager; 
class DelayedCallManager; template <> void RegisterClass<DelayedCallManager>();
class GraphicsSettings; template <> void RegisterClass<GraphicsSettings>();
class InputManager; template <> void RegisterClass<InputManager>();
class MasterServerInterface; template <> void RegisterClass<MasterServerInterface>();
class MonoManager; template <> void RegisterClass<MonoManager>();
class NavMeshProjectSettings; 
class NetworkManager; template <> void RegisterClass<NetworkManager>();
class PerformanceReportingManager; 
class Physics2DSettings; template <> void RegisterClass<Physics2DSettings>();
class PhysicsManager; 
class PlayerSettings; template <> void RegisterClass<PlayerSettings>();
class QualitySettings; template <> void RegisterClass<QualitySettings>();
class ResourceManager; template <> void RegisterClass<ResourceManager>();
class RuntimeInitializeOnLoadManager; template <> void RegisterClass<RuntimeInitializeOnLoadManager>();
class ScriptMapper; template <> void RegisterClass<ScriptMapper>();
class TagManager; template <> void RegisterClass<TagManager>();
class TimeManager; template <> void RegisterClass<TimeManager>();
class UnityAnalyticsManager; 
class UnityConnectSettings; template <> void RegisterClass<UnityConnectSettings>();
class LevelGameManager; template <> void RegisterClass<LevelGameManager>();
class LightmapSettings; template <> void RegisterClass<LightmapSettings>();
class NavMeshSettings; 
class OcclusionCullingSettings; 
class RenderSettings; template <> void RegisterClass<RenderSettings>();
class RenderPassAttachment; 

void RegisterAllClasses()
{
void RegisterBuiltinTypes();
RegisterBuiltinTypes();
	//Total: 72 non stripped classes
	//0. Behaviour
	RegisterClass<Behaviour>();
	//1. Unity::Component
	RegisterClass<Unity::Component>();
	//2. EditorExtension
	RegisterClass<EditorExtension>();
	//3. Camera
	RegisterClass<Camera>();
	//4. GameObject
	RegisterClass<GameObject>();
	//5. Renderer
	RegisterClass<Renderer>();
	//6. GUIElement
	RegisterClass<GUIElement>();
	//7. GUILayer
	RegisterClass<GUILayer>();
	//8. MonoBehaviour
	RegisterClass<MonoBehaviour>();
	//9. Shader
	RegisterClass<Shader>();
	//10. NamedObject
	RegisterClass<NamedObject>();
	//11. Material
	RegisterClass<Material>();
	//12. Sprite
	RegisterClass<Sprite>();
	//13. SpriteRenderer
	RegisterClass<SpriteRenderer>();
	//14. Texture
	RegisterClass<Texture>();
	//15. Texture2D
	RegisterClass<Texture2D>();
	//16. RenderTexture
	RegisterClass<RenderTexture>();
	//17. Transform
	RegisterClass<Transform>();
	//18. UI::RectTransform
	RegisterClass<UI::RectTransform>();
	//19. Mesh
	RegisterClass<Mesh>();
	//20. Rigidbody2D
	RegisterClass<Rigidbody2D>();
	//21. Collider2D
	RegisterClass<Collider2D>();
	//22. Animator
	RegisterClass<Animator>();
	//23. TextRendering::Font
	RegisterClass<TextRendering::Font>();
	//24. UI::Canvas
	RegisterClass<UI::Canvas>();
	//25. UI::CanvasGroup
	RegisterClass<UI::CanvasGroup>();
	//26. UI::CanvasRenderer
	RegisterClass<UI::CanvasRenderer>();
	//27. AudioClip
	RegisterClass<AudioClip>();
	//28. SampleClip
	RegisterClass<SampleClip>();
	//29. AudioListener
	RegisterClass<AudioListener>();
	//30. AudioBehaviour
	RegisterClass<AudioBehaviour>();
	//31. AudioSource
	RegisterClass<AudioSource>();
	//32. BoxCollider2D
	RegisterClass<BoxCollider2D>();
	//33. PreloadData
	RegisterClass<PreloadData>();
	//34. Cubemap
	RegisterClass<Cubemap>();
	//35. Texture3D
	RegisterClass<Texture3D>();
	//36. Texture2DArray
	RegisterClass<Texture2DArray>();
	//37. MeshFilter
	RegisterClass<MeshFilter>();
	//38. MeshRenderer
	RegisterClass<MeshRenderer>();
	//39. LowerResBlitTexture
	RegisterClass<LowerResBlitTexture>();
	//40. BuildSettings
	RegisterClass<BuildSettings>();
	//41. GlobalGameManager
	RegisterClass<GlobalGameManager>();
	//42. GameManager
	RegisterClass<GameManager>();
	//43. DelayedCallManager
	RegisterClass<DelayedCallManager>();
	//44. GraphicsSettings
	RegisterClass<GraphicsSettings>();
	//45. InputManager
	RegisterClass<InputManager>();
	//46. PlayerSettings
	RegisterClass<PlayerSettings>();
	//47. ResourceManager
	RegisterClass<ResourceManager>();
	//48. RuntimeInitializeOnLoadManager
	RegisterClass<RuntimeInitializeOnLoadManager>();
	//49. ScriptMapper
	RegisterClass<ScriptMapper>();
	//50. TagManager
	RegisterClass<TagManager>();
	//51. TimeManager
	RegisterClass<TimeManager>();
	//52. QualitySettings
	RegisterClass<QualitySettings>();
	//53. MonoManager
	RegisterClass<MonoManager>();
	//54. MasterServerInterface
	RegisterClass<MasterServerInterface>();
	//55. NetworkManager
	RegisterClass<NetworkManager>();
	//56. MonoScript
	RegisterClass<MonoScript>();
	//57. TextAsset
	RegisterClass<TextAsset>();
	//58. UnityConnectSettings
	RegisterClass<UnityConnectSettings>();
	//59. CloudWebServicesManager
	RegisterClass<CloudWebServicesManager>();
	//60. AudioManager
	RegisterClass<AudioManager>();
	//61. Physics2DSettings
	RegisterClass<Physics2DSettings>();
	//62. FlareLayer
	RegisterClass<FlareLayer>();
	//63. RenderSettings
	RegisterClass<RenderSettings>();
	//64. LevelGameManager
	RegisterClass<LevelGameManager>();
	//65. LightmapSettings
	RegisterClass<LightmapSettings>();
	//66. PhysicsMaterial2D
	RegisterClass<PhysicsMaterial2D>();
	//67. CircleCollider2D
	RegisterClass<CircleCollider2D>();
	//68. CapsuleCollider2D
	RegisterClass<CapsuleCollider2D>();
	//69. PolygonCollider2D
	RegisterClass<PolygonCollider2D>();
	//70. Effector2D
	RegisterClass<Effector2D>();
	//71. PlatformEffector2D
	RegisterClass<PlatformEffector2D>();

}
