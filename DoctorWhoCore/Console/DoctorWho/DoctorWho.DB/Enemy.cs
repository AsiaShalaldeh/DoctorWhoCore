namespace DoctorWho.DB
{
    public class Enemy
    {
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }
        public IList<EpisodeEnemy> EpisodeEnemies { get; set; }
    }
}
