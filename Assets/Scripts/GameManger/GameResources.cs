using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Audio;

public class GameResources : MonoBehaviour
{
    private static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }
            return instance;
        }
    }

    #region Header DUNGEON
    [Space(10)]
    [Header("DUNGEON")]
    #endregion
    #region Tooltip
    [Tooltip("Populate with the dungeon RoomNodeTypeListSO")]
    #endregion


    public RoomNodeTypeListSO roomNodeTypeList;

    public CurrentPlayer currentPlayer;



    #region Header MUSIC
    [Space(10)]
    [Header("MUSIC")]
    #endregion Header MUSIC
    #region Tooltip
    [Tooltip("Populate with the music master mixer group")]
    #endregion
    public AudioMixerGroup musicMasterMixerGroup;
    #region Tooltip
    [Tooltip("music on full snapshot")]
    #endregion Tooltip
    public AudioMixerSnapshot musicOnFullSnapshot;
    #region Tooltip
    [Tooltip("music low snapshot")]
    #endregion Tooltip
    public AudioMixerSnapshot musicLowSnapshot;
    #region Tooltip
    [Tooltip("music off snapshot")]
    #endregion Tooltip
    public AudioMixerSnapshot musicOffSnapshot;

    #region Tooltip
    [Tooltip("Main menu music scriptable object")]
    #endregion Tooltip
    public MusicTrackSO mainMenuMusic;


    #region Header SOUNDS
    [Space(10)]
    [Header("SOUNDS")]
    #endregion Header
    #region Tooltip
    [Tooltip("Populate with the sounds master mixer group")]
    #endregion
    public AudioMixerGroup soundsMasterMixerGroup;

    #region Tooltip
    [Tooltip("Door open close sound effect")]
    #endregion Tooltip
    public SoundEffectSO doorOpenCloseSoundEffect;


    #region Header MATERIALS
    [Space(10)]
    [Header("MATERIALS")]
    #endregion
    #region Tooltip
    [Tooltip("Dimmed Material")]
    #endregion
    public Material dimmedMaterial;

    #region Tooltip
    [Tooltip("Sprite-Lit-Default Material")]
    #endregion
    public Material litMaterial;

    #region Tooltip
    [Tooltip("Populate with the Variable Lit Shader")]
    #endregion
    public Shader variableLitShader;


    #region Header SPECIAL TILEMAP TILES
    [Space(10)]
    [Header("SPECIAL TILEMAP TILES")]
    #endregion Header SPECIAL TILEMAP TILES
    #region Tooltip
    [Tooltip("Collision tiles that the enemies can navigate to")]
    #endregion Tooltip


    public TileBase[] enemyUnwalkableCollisionTilesArray;
    #region Tooltip
    [Tooltip("Preferred path tile for enemy navigation")]
    #endregion Tooltip
    public TileBase preferredEnemyPathTile;

    #region Header UI
    [Space(10)]
    [Header("UI")]
    #endregion
    #region Tooltip
    [Tooltip("Populate with ammo icon prefab")]
    #endregion
    public GameObject ammoIconPrefab;

    #region Header MINIMAP
    [Space(10)]
    [Header("MINIMAP")]
    #endregion
    #region Tooltip
    [Tooltip("Minimap skull prefab")]
    #endregion
    public GameObject minimapSkullPrefab;



    #region Validation
#if UNITY_EDITOR
    // Validate the scriptable object details entered
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(roomNodeTypeList), roomNodeTypeList);
        HelperUtilities.ValidateCheckNullValue(this, nameof(currentPlayer), currentPlayer);
        HelperUtilities.ValidateCheckNullValue(this, nameof(soundsMasterMixerGroup), soundsMasterMixerGroup);
        HelperUtilities.ValidateCheckNullValue(this, nameof(mainMenuMusic), mainMenuMusic);

        HelperUtilities.ValidateCheckNullValue(this, nameof(doorOpenCloseSoundEffect), doorOpenCloseSoundEffect);
        HelperUtilities.ValidateCheckNullValue(this, nameof(litMaterial), litMaterial);
        HelperUtilities.ValidateCheckNullValue(this, nameof(dimmedMaterial), dimmedMaterial);
        HelperUtilities.ValidateCheckNullValue(this, nameof(variableLitShader), variableLitShader);
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(enemyUnwalkableCollisionTilesArray), enemyUnwalkableCollisionTilesArray);
        HelperUtilities.ValidateCheckNullValue(this, nameof(preferredEnemyPathTile), preferredEnemyPathTile);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicMasterMixerGroup), musicMasterMixerGroup);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicOnFullSnapshot), musicOnFullSnapshot);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicLowSnapshot), musicLowSnapshot);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicOffSnapshot), musicOffSnapshot);

        HelperUtilities.ValidateCheckNullValue(this, nameof(ammoIconPrefab), ammoIconPrefab);

        HelperUtilities.ValidateCheckNullValue(this, nameof(minimapSkullPrefab), minimapSkullPrefab);

    }

#endif
    #endregion

}
