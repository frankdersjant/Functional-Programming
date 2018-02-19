using Domain.Infrastructure;
using System;

namespace Domain
{
    public class CustomerManagement : Entity
    {
        public string Name { get; protected set; }
        public string PrimaryEmail { get; protected set; }
        public string SecondaryEmail { get; protected set; }
        public EMailCampaign EmailCampaign { get; protected set; }
        public CustomerStatus Status { get; protected set; }
        public Industry Industry { get; protected set; }
        public decimal Balance { get; set; }
        public string BillingInfo { get; set; }

        public CustomerManagement(string name, EMailValue primaryEmail, string secondaryEmail, Industry industry) : base()
        {
            Name = name;
            PrimaryEmail = primaryEmail;
            SecondaryEmail = secondaryEmail;
          //  EmailingSettings = GetEmailCampaign(industry, false);
            Status = CustomerStatus.Regular;
        }

        public EMailCampaign GetMailCampaign(Industry industry)
        {
            return EMailCampaign.Generic;
        }

        public void DisableEmailing()
        {
         //   EmailingSettings = EmailingSettings.DisableEmailing();
        }

        public void UpdateIndustry(Industry industry)
        {
           // EmailingSettings = EmailingSettings.ChangeIndustry(industry);
        }

        public bool CanBePromoted()
        {
            return Status != CustomerStatus.Gold;
        }

        public virtual void Promote()
        {
            if (!CanBePromoted())
                throw new InvalidOperationException();

            switch (Status)
            {
                case CustomerStatus.Regular:
                    Status = CustomerStatus.Preferred;
                    break;

                case CustomerStatus.Preferred:
                    Status = CustomerStatus.Gold;
                    break;

                case CustomerStatus.Gold:
                    throw new InvalidOperationException();

                default:
                    throw new InvalidOperationException();
            }
        }

        public void AddBalance(MoneyToCharge amount)
        {
            Balance += amount;
        }
    }
}
