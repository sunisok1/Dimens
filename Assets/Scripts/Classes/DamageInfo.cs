
     using Classes.Entities.Controller;

     namespace Classes
     {
         public class DamageInfo
         {
             public enum DamageType
             {
                 Normal,
                 Thorns,
                 HpLoss
             }

             public IUserController owner;
             public string name;
             public DamageType type;
             public int num;

             public DamageInfo(IUserController damageSource, int num, DamageType type = DamageType.Normal)
             {
                 this.owner = damageSource;
                 this.type = type;
                 this.num = num;
             }
         }
     }
