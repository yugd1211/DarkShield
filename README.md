# DarkShield

> 경일 게임아카데미 8기 3D 팀 프로젝트 (3인 팀)

Unity로 개발된 액션 RPG 게임 프로젝트입니다.

## 🎮 프로젝트 개요

**DarkShield**는 다크 판타지 세계관의 액션 RPG 게임으로, 플레이어가 다양한 적들과 전투하며 성장하는 게임입니다.

- **프로젝트 기간**: 2024.11.26~2024.12.12 (17일)
- **팀 구성**: 3인 팀 프로젝트
- **개발 엔진**: 2022.3.50f1
- **장르**: 액션 RPG

## 👥 팀원 소개

| 팀장 | 팀원 | 팀원 |
|------|------|------|
| <img src="https://avatars.githubusercontent.com/u/85577502?v=4" width="150"/> | <img src="https://avatars.githubusercontent.com/u/168985175?v=4" width="150"/> | <img src="https://avatars.githubusercontent.com/u/165467444?v=4" width="150"/> |
| **유경동** | **사동혁** | **이서형** |
| [GitHub](https://github.com/yugd1211) | [GitHub](https://github.com/SaDongHuck) | [GitHub](https://github.com/LeeSeoHyeong1031) |


## 🎯 주요 기능

### 플레이어 시스템
- **입력 관리**: [`PlayerInputManager`](02.Scripts/Player/PlayerInputManager.cs)를 통한 플레이어 입력 처리
  - 이동, 대시, 스킬 입력
  - 콤보 어택 시스템
  - 마우스 및 키보드 입력 지원

- **애니메이션 이벤트**: [`AnimationEventEffects`](02.Scripts/Player/AnimationEventEffects.cs)를 통한 이펙트 시스템
  - 스킬 이펙트 생성 및 관리
  - 타겟 스캔 및 데미지 처리

### 적 AI 시스템
- **보스 캐릭터**: [`ChaosEmperor`](02.Scripts/Enemy/RangeEnemy/ChaosEmperor.cs) 
  - HP 바 표시 시스템
  - 포효 애니메이션 및 다양한 공격 패턴

- **엘리트 적**: [`DeathBow`](02.Scripts/Enemy/RangeEnemy/DeathBow.cs)
  - 돌진 공격과 원거리 공격 패턴
  - 오브젝트 풀링을 활용한 투사체 시스템

- **투사체 시스템**: [`Projectile`](02.Scripts/Enemy/Projectile.cs)
  - 오브젝트 풀링으로 최적화된 투사체 관리

- **FSM 시스템**: [`DeadState`](02.Scripts/Enemy/FSM/DeadState.cs)
  - 적의 상태 관리 (생존/사망)
  - 사망 시 코인 드롭 시스템

### 업그레이드 시스템
- **스탯 업그레이드**: 골드를 소모하여 플레이어 능력치 강화
- 업그레이드 비용 증가 시스템
- UI 업데이트 및 시각적 피드백
  
### 이펙트 시스템
- **Magic Slashes FX**: [08.UsedResources/OrdosFX/Magic Slashes FX/](08.UsedResources/OrdosFX/Magic%20Slashes%20FX/)
  - 마법 검격 이펙트
  - 파티클 중력 포인트 시스템
  - 포스트 프로세싱 이펙트

- **Lava Flowing Shader**: [08.UsedResources/Lava_Flowing_Shader/](08.UsedResources/Lava_Flowing_Shader/)
  - 용암 흐름 셰이더 이펙트

### 캐릭터 모델
- **Kawaii Slimes**: [08.UsedResources/Kawaii Slimes/](08.UsedResources/Kawaii%20Slimes/)
  - 슬라임 적 캐릭터 모델
  - Unity-chan 스타일 셰이더

- **Polygonmaker**: [08.UsedResources/Enemy/Polygonmaker/](08.UsedResources/Enemy/Polygonmaker/)
  - 판타지 적 캐릭터 모델
  - 오크, 고블린 등 다양한 적 타입

### UI 시스템
- **TextMeshPro**: 고품질 텍스트 렌더링
- 리치 텍스트 지원으로 색상 및 스타일링


## 📁 프로젝트 구조

```
DarkShield/
├── 01.Scenes/              # 게임 씬 파일들
├── 02.Scripts/             # C# 스크립트 파일들
│   ├── Player/             # 플레이어 관련 스크립트
│   ├── Enemy/              # 적 캐릭터 관련 스크립트
│   └── Upgrade/            # 업그레이드 시스템
├── 03.Prefabs/             # Unity 프리팹 파일들
├── 04.Materials/           # 머티리얼 에셋들
├── 05.Animations/          # 애니메이션 파일들
├── 06.Audios/              # 오디오 리소스
├── 07.ScriptableObjects/   # ScriptableObject 에셋들
├── 08.UsedResources/       # 외부 에셋 및 리소스
├── GentlelandSettings/     # 게임 설정 파일들
├── TextMesh Pro/           # TextMeshPro 리소스
└── Resources/              # Unity Resources 폴더
```
