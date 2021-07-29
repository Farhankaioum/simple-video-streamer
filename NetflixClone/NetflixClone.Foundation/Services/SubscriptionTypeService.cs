using Microsoft.AspNetCore.Identity;
using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Exceptions;
using NetflixClone.Foundation.Helpers;
using NetflixClone.Foundation.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetflixClone.Foundation.Services
{
    public class SubscriptionTypeService : ISubscriptionTypeService
    {
        private readonly IRepository<SubscriptionType, int> _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SubscriptionTypeService(
            IRepository<SubscriptionType, int> repository,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void AddSubscription(SubscriptionType subscription)
        {
            var count = _repository.GetCount(x => x.Name == subscription.Name);

            if (count > 0)
            {
                throw new DuplicationException("Name Already Exists");
            }
            _repository.Insert(subscription);
        }

        public void DeleteSubscription(SubscriptionType subscription)
        {
            _repository.Delete(subscription);
        }

        public SubscriptionType GetSubscriptionById(int id)
        {
            return _repository.GetById(id);
        }

        public IList<SubscriptionType> SubscriptionList()
        {
            return _repository.GetList();
        }

        public void UpdateSubscription(SubscriptionType subscription)
        {
            var count = _repository.GetCount(x => x.Name == subscription.Name && x.Id != subscription.Id);

            if (count > 0)
            {
                throw new DuplicationException("Name Already Exists");
            }

            _repository.Update(subscription);
        }

        public async Task<bool> AddUserSubscription(string userId, int subscriptionId)
        {
            var subscription = GetSubscriptionById(subscriptionId);
            if (subscription == null)
                throw new NotFoundException("Subscription not found");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new NotFoundException("User not found");

            user.SubscriptionTypeId = subscriptionId;
            user.SubscriptionDate = DateTime.Now;
            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                var roleAlreadyExists = await _userManager.IsInRoleAsync(user, ConstantValue.SUBSCRIBE_USER_ROLE);
                if(!roleAlreadyExists)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, ConstantValue.SUBSCRIBE_USER_ROLE);
                    if (!roleResult.Succeeded)
                    {
                        user.SubscriptionTypeId = subscriptionId;
                        user.SubscriptionDate = DateTime.Now;
                        await _userManager.UpdateAsync(user);
                        return false;
                    }    
                }
            }

            return result.Succeeded;
        }
    }
}
